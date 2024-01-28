using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class ValuesController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;
        public ValuesController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }


        //[Authorize]
        [HttpGet("Get")]
        public int Get()
        {
            //var user=User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Convert.ToInt32("na");
        }

        [HttpGet("PaymentType")]
        public async Task<IEnumerable<PaymentTypeMaster>> GetPaymentType()
        {
            //var user=User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _paymentTypeService.GetAllAsync();
            return result.ToList();
        }
    }
}
