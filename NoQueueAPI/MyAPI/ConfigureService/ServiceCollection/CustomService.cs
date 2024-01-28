using DataAccessLibrary;
using DataAccessLibrary.Models;
using DataAccessLibrary.IRepositories;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Repositories;
using DataAccessLibrary.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using DataAccessLibrary.Mapper;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace MyAPI.ConfigureService.ServiceCollection
{
    public class CustomService : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<ILogin, LoginRepos>();
            services.AddTransient<ILoginService, LoginService>();

            services.AddTransient<IPaymentTypeMasterRepos, PaymentTypeMasterRepos>();
            services.AddTransient<IPaymentTypeService, PaymentTypeMasterService>();

            services.AddTransient(typeof(ICompanyRepos<>),typeof(CompanyRepos<>));
            services.AddTransient(typeof(ICompanyService<>), typeof(CompanyService<>));

            services.AddTransient(typeof(IRestaurantRepository<>), typeof(RestaurantRepository<>));
            services.AddTransient(typeof(IRestaurantService<>), typeof(RestaurantService<>));

            services.AddTransient(typeof(ILocationRepos<>), typeof(LocationRepos<>));
            services.AddTransient(typeof(ILocationService<>), typeof(LocationService<>));

            services.AddTransient(typeof(ICustomerRepos<>), typeof(CustomerRepos<>));
            services.AddTransient(typeof(ICustomerService<>), typeof(CustomerService<>));

            services.AddTransient(typeof(ICartRepos<>), typeof(CartRepos<>));
            services.AddTransient(typeof(ICartService<>), typeof(CartService<>));

            services.AddTransient(typeof(IUserRepos<>), typeof(UserRepos<>));
            services.AddTransient(typeof(IUserService<>), typeof(UserService<>));

            services.AddTransient(typeof(ITableService<>), typeof(TableService<>));
            services.AddTransient(typeof(ITableRepos<>), typeof(TableRepos<>));

            services.AddTransient(typeof(IFoodItemsService<>), typeof(FoodItemsService<>));
            services.AddTransient(typeof(IFoodItemsRepos<>), typeof(FoodItemsRepos<>));

            services.AddTransient(typeof(IManageStaffService<>), typeof(ManageStaffService<>));
            services.AddTransient(typeof(IManageStaffRepos<>), typeof(ManageStaffRepos<>));

            services.AddTransient(typeof(IDiscountService<>), typeof(DiscountService<>));
            services.AddTransient(typeof(IDiscountRepos<>), typeof(DiscountRepos<>));

            services.AddTransient(typeof(ITransactionService<>), typeof(TransactionService<>));
            services.AddTransient(typeof(ITransactionRepos<>), typeof(TransactionRepos<>));

            services.AddTransient(typeof(IFilesService), typeof(FilesService));

            services.AddTransient(typeof(ISmsService), typeof(SmsService));

            services.AddTransient(typeof(IFoodCategoryService<>), typeof(FoodCategoryService<>));
            services.AddTransient(typeof(IFoodCategoryRepos<>), typeof(FoodCategoryRepos<>));
            services.AddAutoMapper(typeof(Program), typeof(GuardianMapper));

            services.AddMemoryCache();
            /*  services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<NoQContext>();*/
            //for saving from cycles
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder
                        .AllowAnyOrigin()   
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }
    }
}