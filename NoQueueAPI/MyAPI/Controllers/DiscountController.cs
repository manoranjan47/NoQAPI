using AutoMapper;
using DataAccessLibrary.DTO;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using MyAPI.ConfigureService.ServiceCollection;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDiscountService<Discount> _discountService;
        private readonly IFilesService _file;
        public DiscountController(
            IMapper mapper, 
            IFilesService file,
            IDiscountService<Discount> discountService
            
        )
        {
            _mapper = mapper;
            _discountService = discountService;
            _file = file;
        }

        #region Discount
        [HttpPost]
        [Route("AddDiscount")]
        public async Task<IActionResult> AddDiscount([FromBody] DiscountDTO company)
        {
            var temp = _mapper.Map<Discount>(company);
            _discountService.UpdateAsync(temp);
            return Ok(await _discountService.SaveChangesAsync());
        }

        [HttpPut]
        [Route("UpdateDiscount")]
        public async Task<IActionResult> UpdateDiscount([FromBody] DiscountDTO company, int Id)
        {
            var data = await _discountService.GetBrachesDiscountsAsync(Id, company.BranchId);
            var discount = data.FirstOrDefault();
            if (discount == null)
            {
                return NotFound(false);
            }
            _mapper.Map(company, discount);
            discount.ModifiedDate = DateTime.UtcNow;
            _discountService.UpdateAsync(discount);
            return Ok(await _discountService.SaveChangesAsync());
        }

        [HttpGet]
        [Route("GetAllDiscount")]
        public async Task<ActionResult<IEnumerable<Discount>>> GetAllDiscount(int? DiscountId = null, int? BranchId = null)
        {
            return Ok(await _discountService.GetBrachesDiscountsAsync(DiscountId,BranchId));
        }
        [HttpDelete]
        [Route("DeleteDiscount")]
        public async Task<IActionResult> DeleteDiscountItem([FromBody] DiscountDTO cart, int Id)
        {
            var data = await _discountService.GetBrachesDiscountsAsync(Id, cart.BranchId);
            var discount = data.FirstOrDefault();
            if (discount == null)
            {
                return NotFound(false);
            }
            discount.IsDeleted = true;
            discount.ModifiedDate = DateTime.UtcNow;
            _discountService.UpdateAsync(discount);
            return Ok(await _discountService.SaveChangesAsync());
        }
        #endregion
    }
}
