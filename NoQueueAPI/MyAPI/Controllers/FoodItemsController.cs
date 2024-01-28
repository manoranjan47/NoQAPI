using AutoMapper;
using DataAccessLibrary.DTO;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using DataAccessLibrary.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAPI.ConfigureService.ServiceCollection;
using MyAPI.Middlewares.Authentication;
using System.ComponentModel.Design;
using Twilio.TwiML.Voice;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    public class FoodItemsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFoodItemsService<FoodItem> _foodService;
        private readonly IFilesService _file;
        public FoodItemsController(
            IMapper mapper,
            IFoodItemsService<FoodItem> foodService,
            IFilesService file
        )
        {
            _mapper = mapper;
            _foodService = foodService;
            _file = file;
        }
        #region FoodItem
        [HttpGet]
        [Route("GetAllFoodItem")]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetAllFoodItem(int? FoodItemId=null,int? BranchId=null,int? FoodCategoryId=null,int? FoodSubCategoryId=null,bool? IsNonVeg=null)
        {
            return Ok(await _foodService.GetAllFoodItemsAsync(FoodItemId,BranchId,FoodCategoryId,FoodSubCategoryId));
        }

        [HttpPost]
        [Route("AddFoodItem")]
        public async Task<IActionResult> AddFoodItem([FromBody] FoodItemDTO company)
        {
            var temp = _mapper.Map<FoodItem>(company);
            temp.FoodImage = await _file.GetFilePath(company.FoodImage, "foodItem");

            _foodService.InsertAsync(temp);
            return Ok(await _foodService.SaveChangesAsync());
        }

        [HttpPut]
        [Route("UpdateFoodItem")]
        public async Task<IActionResult> UpdateFoodItem([FromBody] FoodItemDTO company, int Id)
        {
            var data = await _foodService.GetAllFoodItemsAsync(Id, company.BranchId, company.FoodCategoryId, company.FoodSubCategoryId);
            var foodItem = data.FirstOrDefault();
            if (foodItem == null)
            {
                return NotFound(false);
            }
            _mapper.Map(company, foodItem);
            foodItem.ModifiedDate = DateTime.UtcNow;
            _foodService.UpdateAsync(foodItem);
            return Ok(await _foodService.SaveChangesAsync());
        }
        [HttpDelete]
        [Route("DeleteFoodItem")]
        public async Task<IActionResult> DeleteFoodItem([FromBody] FoodItemDTO food, int Id)
        {
            var data = await _foodService.GetAllFoodItemsAsync(Id, food.BranchId, food.FoodCategoryId, food.FoodSubCategoryId);
            var foodItem = data.FirstOrDefault();
            if (foodItem == null)
            {
                return NotFound(false);
            }
            foodItem.IsDeleted = true;
            foodItem.ModifiedDate = DateTime.UtcNow;
            _foodService.UpdateAsync(foodItem);
            return Ok(await _foodService.SaveChangesAsync());
        }
        #endregion
    }
}
