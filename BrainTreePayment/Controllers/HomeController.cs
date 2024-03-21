using Braintree;
using BrainTreePayment.Business.Layer;
using BrainTreePayment.Business.Layer.Data;
using BrainTreePayment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BrainTreePayment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPaymentManager _paymentManager;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IPaymentManager paymentManager)
        {
            _logger = logger;
            _paymentManager = paymentManager;
        }

        public IActionResult Index()
        {
            var order = new BookPurchaseVM
            {
                Id = 2,
                Description = "Hellow man",
                Author = "Me",
                Thumbnail = "This is thumbnail",
                Title = "This is title",
                Price = "230",
                Nonce = ""
            };

            var data = _paymentManager.ClientOrderProcessingHandler(order);
            
            ViewBag.ClientToken = data.ClientToken;

            return View(data.BookPurchaseVM);
        }

        [HttpPost]
        public IActionResult Create(BookPurchaseVM model)
        {
            var result = _paymentManager.ClientPaymentProcessingHandler(model); 

            if(result) 
                return RedirectToAction(nameof(Index));
            else
                return RedirectToAction(nameof(Index));
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
