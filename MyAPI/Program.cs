using DataAccessLibrary.Mapper;
using DataAccessLibrary.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using MyAPI.ConfigureService.ServiceCollection;
using MyAPI.Middlewares;
using Twilio.Clients;

var builder = WebApplication.CreateBuilder(args);
var mySpecification = builder.Configuration.GetSection("specficationString").ToString();
builder.Services.InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// in general

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
              Path.Combine(Directory.GetCurrentDirectory(), "uploads")),
    RequestPath = "/api/uploads"
});

app.UseCors("AllowSpecificOrigin");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(mySpecification);
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<GlobalErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
