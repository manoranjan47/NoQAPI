using AutoMapper;
using DataAccessLibrary.DTO;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using MyAPI.ConfigureService.ServiceCollection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITransactionService<Transaction> _transactionService;
        private readonly ITransactionService<BranchOrders> _ordersService;
        private readonly ICartService<Cart> _cartService;
        private readonly ICartService<StatusMaster> _statusService;

        private readonly IFilesService _file;
        public TransactionsController(
            IMapper mapper,
            IFilesService file,
            ITransactionService<Transaction> transactionService,
            ITransactionService<BranchOrders> ordersService,
            ICartService<Cart> cartService,
            ICartService<StatusMaster> statusService

        )
        {
            _mapper = mapper;
            _transactionService = transactionService;
            _ordersService = ordersService;
            _cartService = cartService;
            _file = file;
            _ordersService= ordersService;
            _statusService= statusService;
        }


        [HttpPost]
        [Route("AddTransaction")]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionDTO company)
        {
            var temp = _mapper.Map<Transaction>(company);
            _transactionService.UpdateAsync(temp);
            return Ok(await _transactionService.SaveChangesAsync());
        }




        #region Transaction
        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<ActionResult<IEnumerable<BranchOrders>>> GetAllBranchOrders(int? OrderId=null, int? TransactionId = null, int? BranchId = null, int? CustomerId = null)
        {
            return Ok(await _ordersService.GetBranchOrdersAsync(OrderId, TransactionId, BranchId, CustomerId));
        }
        [HttpGet]
        [Route("GetAllStatus")]
        public async Task<ActionResult<IEnumerable<StatusMaster>>> GetAllStatus()
        {
            return Ok(await _statusService.GetAllAsync());
        }
        [HttpPut]
        [Route("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus(int OrderId, int StatusId, int UpdatedBy)
        {
            var temp = await _ordersService.GetBranchOrdersAsync(OrderId, null,null, null);
            var data = temp.FirstOrDefault();
            if (data == null)
            {
                return NotFound(false);
            }
            data.StatusId = StatusId;
            data.ModifiedBy = UpdatedBy;
            data.ModifiedDate = DateTime.UtcNow;
            _ordersService.UpdateAsync(data);
            return Ok(await _ordersService.SaveChangesAsync());
        }
        [HttpPost]
        [Route("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder([FromBody] TransactionDTO company)
        {
            var temp = _mapper.Map<Transaction>(company);
            _transactionService.InsertAsync(temp);
            await _transactionService.SaveChangesAsync();
            var order = _mapper.Map<BranchOrders>(company);
            order.OrderStatus = "orders";
            order.StatusId = 4;
            order.TransactionId=temp.TransactionId;
            _ordersService.InsertAsync(order);
            _ordersService.SaveChangesAsync();
            var carts = await _cartService.GetCartAsync(null, company.CartId, null);
            var cartData = carts.FirstOrDefault();
            cartData.ModifiedDate = DateTime.UtcNow;
            cartData.IsActive = false;
            _cartService.UpdateAsync(cartData);
            return Ok(await _cartService.SaveChangesAsync());
        }

        [HttpPut]
        [Route("UpdateTransaction")]
        public async Task<IActionResult> UpdateTransaction([FromBody] DiscountDTO company, int Id)
        {
            var data = await _transactionService.GetTransactionAsync(Id, company.BranchId);
            var discount = data.FirstOrDefault();
            if (discount == null)
            {
                return NotFound(false);
            }
            _mapper.Map(company, discount);
            discount.ModifiedDate = DateTime.UtcNow;
            _transactionService.UpdateAsync(discount);
            return Ok(await _transactionService.SaveChangesAsync());
        }

        [HttpGet]
        [Route("GetAllTransaction")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetAllTransaction(int? TransactionId = null, int? BranchId = null)
        {
            return Ok(await _transactionService.GetTransactionAsync(TransactionId, BranchId));
        }
        [HttpDelete]
        [Route("DeleteTransaction")]
        public async Task<IActionResult> DeleteTransactionItem([FromBody] DiscountDTO cart, int Id)
        {
            var data = await _transactionService.GetTransactionAsync(Id, cart.BranchId);
            var discount = data.FirstOrDefault();
            if (discount == null)
            {
                return NotFound(false);
            }
            discount.IsDeleted = true;
            discount.ModifiedDate = DateTime.UtcNow;
            _transactionService.UpdateAsync(discount);
            return Ok(await _transactionService.SaveChangesAsync());
        }
        #endregion
    }
}
