using AutoMapper;
using DataAccessLibrary.DTO;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using DataAccessLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using MyAPI.ConfigureService.ServiceCollection;
using System.ComponentModel.DataAnnotations;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFoodCategoryService<FoodCategory> _foodcategoryService;
        private readonly IFoodCategoryService<FoodSubCategory> _foodSubCategoryService;
        private readonly IFilesService _file;

        public FoodCategoryController(
          IMapper mapper,
          IFilesService file,
          IFoodCategoryService<FoodCategory> foodcategoryService,
          IFoodCategoryService<FoodSubCategory> foodSubCategoryService
          )
        {
            _mapper = mapper; 
            _file = file;
            _foodcategoryService = foodcategoryService;
            _foodSubCategoryService = foodSubCategoryService;
        }
        #region FoodCategory
        [HttpPost]
        [Route("AddFoodCategory")]
        public async Task<IActionResult> AddCategory([FromBody] FoodCategoryDTO company)
        {
            var temp = _mapper.Map<FoodCategory>(company);
            temp.FoodCategoryImage = await _file.GetFilePath(temp.FoodCategoryImage, "category");
            _foodcategoryService.InsertAsync(temp);
            return Ok(await _foodcategoryService.SaveChangesAsync());
        }

        [HttpPut]
        [Route("UpdateFoodCategory")]
        public async Task<IActionResult> UpdateFoodCategory([FromBody] FoodCategoryDTO company, int Id)
        {
            var data = await _foodcategoryService.GetBrachesCategoryAsync(company.BranchId, Id);
            var foodCategory = data.FirstOrDefault();
            if (foodCategory == null)
            {
                return NotFound(false);
            }
            _mapper.Map(company, foodCategory);
            foodCategory.ModifiedDate = DateTime.UtcNow;
            foodCategory.FoodCategoryImage = await _file.GetFilePath(foodCategory.FoodCategoryImage, "category");
            _foodcategoryService.UpdateAsync(foodCategory);
            return Ok(await _foodcategoryService.SaveChangesAsync());
        }

        [HttpGet]
        [Route("GetAllFoodCategory")]
        public async Task<ActionResult<IEnumerable<FoodCategory>>> GetAllFoodCategory(int? BranchId = null, int? FoodCategoryId = null)
        {
            return Ok(await _foodcategoryService.GetBrachesCategoryAsync(BranchId, FoodCategoryId));
        }
        [HttpDelete]
        [Route("DeleteFoodCategory")]
        public async Task<IActionResult> DeleteFoodCategory([FromBody] FoodCategoryDTO cart, [Required]int Id)
        {
            var data = await _foodcategoryService.GetBrachesCategoryAsync(cart.BranchId, Id);
            var cartData = data.FirstOrDefault();
            if (cartData == null)
            {
                return NotFound(false);
            }
            cartData.IsDeleted = true;
            cartData.ModifiedDate = DateTime.UtcNow;
            _foodcategoryService.UpdateAsync(cartData);
            return Ok(await _foodcategoryService.SaveChangesAsync());
        }
        #endregion

        #region FoodSubCategory
        [HttpPost]
        [Route("AddFoodSubCategory")]
        public async Task<IActionResult> AddFoodSubcategoryCategory([FromBody] FoodSubCategoryDTO company)
        {
            var temp = _mapper.Map<FoodSubCategory>(company);
            temp.FoodSubCategoryImage = await _file.GetFilePath(temp.FoodSubCategoryImage, "subcategory");
            _foodSubCategoryService.InsertAsync(temp);
            return Ok(await _foodSubCategoryService.SaveChangesAsync());
        }

        [HttpPut]
        [Route("UpdateFoodSubCategory")]
        public async Task<IActionResult> UpdateFoodSubcategoryCategory([FromBody] FoodSubCategoryDTO company, int Id)
        {
            var data = await _foodSubCategoryService.GetBrachesSubCategoryAsync(company.FoodCategoryId, Id);
            var foodSubCategory = data.FirstOrDefault();
            if (foodSubCategory == null)
            {
                return NotFound(false);
            }
            _mapper.Map(company, foodSubCategory);
            foodSubCategory.ModifiedDate = DateTime.UtcNow;
            foodSubCategory.FoodSubCategoryImage = await _file.GetFilePath(foodSubCategory.FoodSubCategoryImage, "subcategory");

            _foodSubCategoryService.UpdateAsync(foodSubCategory);
            return Ok(await _foodSubCategoryService.SaveChangesAsync());
        }

        [HttpGet]
        [Route("GetAllFoodSubCategory")]
        public async Task<ActionResult<IEnumerable<FoodSubCategory>>> GetAllFoodSubCategory(int? FoodCategoryId = null, int? FoodSubCategoryId = null)
        {
            return Ok(await _foodSubCategoryService.GetBrachesSubCategoryAsync(FoodCategoryId, FoodSubCategoryId));
        }
        [HttpDelete]
        [Route("DeleteFoodSubCategory")]
        public async Task<IActionResult> DeleteFoodSubCategory([FromBody] FoodSubCategoryDTO cart, [Required] int Id)
        {
            var data = await _foodSubCategoryService.GetBrachesSubCategoryAsync(cart.FoodCategoryId, Id);
            var cartData = data.FirstOrDefault();
            if (cartData == null)
            {
                return NotFound(false);
            }
            cartData.IsDeleted = true;
            cartData.ModifiedDate = DateTime.UtcNow;
            _foodSubCategoryService.UpdateAsync(cartData);
            return Ok(await _foodSubCategoryService.SaveChangesAsync());
        }
        #endregion
    }
}
