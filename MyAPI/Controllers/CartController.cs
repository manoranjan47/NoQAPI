using AutoMapper;
using DataAccessLibrary.DTO;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using DataAccessLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICartService<Cart> _cartService;
        private readonly ICartService<CartItem> _cartItemService;

        public CartController(
            IMapper mapper,
            ICartService<Cart> cartService,
            ICartService<CartItem> cartItemService
        )
        {
            _mapper = mapper;
            _cartService = cartService;
            _cartItemService = cartItemService;
        }
        [HttpPost]
        [Route("AddCart")]
        public async Task<IActionResult> AddCart([FromBody] CartDTO company)
        {
            var temp = _mapper.Map<Cart>(company);
            _cartService.InsertAsync(temp);
            return Ok(await _cartService.SaveChangesAsync());
        }
        [HttpPost]
        [Route("TempAddCart")]
        public async Task<IActionResult> TempAddCart([FromBody] CartDTO company)
        {
            var temp = _mapper.Map<Cart>(company);
            _cartService.InsertAsync(temp);
            await _cartService.SaveChangesAsync();
            return Ok(temp.CartId);
        }
        [HttpPut]
        [Route("UpdateCart")]
        public async Task<IActionResult> UpdateCart([FromBody] CartDTO cart, int Id)
        {
            var data = await _cartService.GetCartAsync(cart.CustomerId, Id, cart.BranchId);
            var cartData = data.FirstOrDefault();
            if (cartData == null)
            {
                return NotFound(false);
            }
            _mapper.Map(cart, cartData);
            cartData.ModifiedDate = DateTime.UtcNow;
            _cartService.UpdateAsync(cartData);
            return Ok(await _cartService.SaveChangesAsync());
        }
        [HttpDelete]
        [Route("DeleteCart")]
        public async Task<IActionResult> DeleteCart([FromBody] CartDTO cart, int Id)
        {
            var data = await _cartService.GetCartAsync(cart.CustomerId, Id,cart.BranchId);
            var cartData = data.FirstOrDefault();
            if (cartData == null)
            {
                return NotFound(false);
            }
            cartData.IsDeleted = true;
            cartData.ModifiedDate = DateTime.UtcNow;
            _cartService.UpdateAsync(cartData);
            return Ok(await _cartService.SaveChangesAsync());
        }
        [HttpGet]
        [Route("GetAllCart")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetAllCart(int? CustomerId = null, int? CartId = null, int? BranchId = null)
        {
            return Ok(await _cartService.GetCartAsync(CustomerId, CartId, BranchId));
        }
        [HttpPost]
        [Route("AddCartItem")]
        public async Task<IActionResult> AddCartItem([FromBody] CartItemDTO company)
        {
            var temp = _mapper.Map<CartItem>(company);
            _cartItemService.InsertAsync(temp);
            await _cartItemService.SaveChangesAsync();

            var cartitems = await _cartItemService.GetCartItemAsync(null, company.CartId, null);
            decimal total = (decimal)cartitems.Sum(x => (decimal)x.Qty * x.Price);

            var data = await _cartService.GetCartAsync(null, company.CartId, null);
            var cartData = data.FirstOrDefault();
            cartData.ModifiedDate = DateTime.UtcNow;
            cartData.Amount = total;
            _cartService.UpdateAsync(cartData);
            return Ok(await _cartService.SaveChangesAsync());
        }

        [HttpPut]
        [Route("UpdateCartItem")]
        public async Task<IActionResult> UpdateCartItem([FromBody] CartItemDTO cart, int Id)
        {
            var data = await _cartItemService.GetCartItemAsync(Id, cart.CartId, cart.FoodItemId);
            var cartItemData = data.FirstOrDefault();
            if (cartItemData == null)
            {
                return NotFound(false);
            }
            _mapper.Map(cart, cartItemData);
            cartItemData.ModifiedDate = DateTime.UtcNow;
            _cartItemService.UpdateAsync(cartItemData);
            await _cartItemService.SaveChangesAsync();

            var cartitems = await _cartItemService.GetCartItemAsync(null, cart.CartId, null);
            decimal total = (decimal)cartitems.Sum(x => (decimal)x.Qty * x.Price);

            var carts = await _cartService.GetCartAsync(null, cart.CartId, null);
            var cartData = carts.FirstOrDefault();
            cartData.ModifiedDate = DateTime.UtcNow;
            cartData.Amount = total;
            _cartService.UpdateAsync(cartData);
            return Ok(await _cartService.SaveChangesAsync());
        }
        [HttpGet]
        [Route("GetAllCartItem")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetAllCartItem(int? CartItemId = null, int? CartId = null, int? FoodItemId = null)
        {
            return Ok(await _cartItemService.GetCartItemAsync(CartItemId, CartId, FoodItemId));
        }
        [HttpDelete]
        [Route("DeleteCartItem")]
        public async Task<IActionResult> DeleteCartItem([FromBody] CartItemDTO cart, int Id)
        {
            var data = await _cartItemService.GetCartItemAsync(Id, cart.CartId, cart.FoodItemId);
            var cartItemData = data.FirstOrDefault();
            if (cartItemData == null)
            {
                return NotFound(false);
            }
            cartItemData.IsDeleted=true;
            cartItemData.ModifiedDate = DateTime.UtcNow;
            _cartItemService.UpdateAsync(cartItemData);
            await _cartItemService.SaveChangesAsync();

            var cartitems = await _cartItemService.GetCartItemAsync(null, cart.CartId, null);
            decimal total = (decimal)cartitems.Sum(x => (decimal)x.Qty * x.Price);

            var carts = await _cartService.GetCartAsync(null, cart.CartId, null);
            var cartData = carts.FirstOrDefault();
            cartData.ModifiedDate = DateTime.UtcNow;
            cartData.Amount = total;
            _cartService.UpdateAsync(cartData);
            return Ok(await _cartService.SaveChangesAsync());
        }
    }
}
