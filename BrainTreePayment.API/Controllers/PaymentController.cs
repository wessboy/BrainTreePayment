using BrainTreePayment.Business.Layer;
using BrainTreePayment.Business.Layer.Data;
using Microsoft.AspNetCore.Mvc;

namespace BrainTreePayment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManager _paymentManager;
        public PaymentController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        

        [HttpPost]
        public IActionResult Pay(BookPurchaseVM bookPurchaseVM)
        {
            //Request.Headers.Authorization = _paymentManager.ClientOrderProcessingHandler(bookPurchaseVM).ClientToken;
            
           

            
            var result = _paymentManager.ClientPaymentProcessingHandler(bookPurchaseVM);

            if (!result)
                return BadRequest("Payment failed to be processed !");
    
        
            return Ok($"Payment for item {bookPurchaseVM.Title} with amount of  {bookPurchaseVM.Price} processed successfuly");
            
        }
    }
}
