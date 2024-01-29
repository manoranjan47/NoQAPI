using AutoMapper;
using DataAccessLibrary.DTO;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccessLibrary.Mapper
{
    public class GuardianMapper : Profile
    {
        public GuardianMapper()
        {
            CreateMap<TransactionDTO, Transaction>().ReverseMap();
            CreateMap<TransactionDTO, BranchOrders>().ReverseMap();

            #region BranchTables
            CreateMap<BranchTablesDTO, BranchTables>().ReverseMap();
            #endregion

            #region BranchStaffTables
            CreateMap<BranchStaffDTO, BranchStaff>().ReverseMap();
            #endregion

            #region Company
            CreateMap<CategoryMasterDTO, CategoryMaster>().ReverseMap();
            CreateMap<CompanyMasterDTO,CompanyMaster>().ReverseMap();
            #endregion

            #region Restaurants
            CreateMap<BranchDTO,Branch>().ReverseMap();
            CreateMap<FoodCategoryDTO,FoodCategory>().ReverseMap();
            CreateMap<FoodItemDTO,FoodItem>().ReverseMap();
            CreateMap<FoodSubCategoryDTO, FoodSubCategory>().ReverseMap();
            CreateMap<BankDetailDTO, BankDetail>().ReverseMap();
            CreateMap<BranchPhotoDTO, BranchPhoto>().ReverseMap();

            #endregion 


            #region Location
            CreateMap<CountryMasterDTO, CountryMaster>().ReverseMap();
            CreateMap<StateMasterDTO, StateMaster>().ReverseMap();
            CreateMap<DistrictMasterDTO, DistrictMaster>().ReverseMap();
            CreateMap<CityMasterDTO, CityMaster>().ReverseMap();
            #endregion

            #region Customer 
            CreateMap<CustomerLoginDTO, Customer>().ReverseMap();
            CreateMap<CustomerDTO, Customer>().ReverseMap();

            CreateMap<CartItemDTO, CartItem>().ReverseMap();
            CreateMap<CartDTO, Cart>().ReverseMap();

            #endregion

        }
    }
}
