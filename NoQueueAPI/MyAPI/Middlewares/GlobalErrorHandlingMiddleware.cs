using Azure;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Components.Web;
using System.Net;
using System.Text.Json.Serialization;

namespace MyAPI.Middlewares
{
    public class GlobalErrorHandlingMiddleware : IMiddleware
    {
        private readonly IErrorHandlingService errorHandlingService;

        public GlobalErrorHandlingMiddleware(IErrorHandlingService errorHandlingService)
        {
            this.errorHandlingService = errorHandlingService;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
             await next(context);
            }
            catch (Exception ex)
            {
                ErrorHandling errorHandling = new ErrorHandling()
                {
                    Message= ex.Message,
                    //StatusCode=(int)HttpStatusCode.InternalServerError
                    StackTrace=ex.StackTrace,
                    CreatedDate= DateTime.Now,
                };

                errorHandlingService.LogError(errorHandling);
                
                
            }
            
        }
    }
}
