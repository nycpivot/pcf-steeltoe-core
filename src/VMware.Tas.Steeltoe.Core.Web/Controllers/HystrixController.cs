using Microsoft.AspNetCore.Mvc;
using VMware.Tas.Steeltoe.Core.Web.Commands;
using VMware.Tas.Steeltoe.Core.Web.Services;

namespace VMware.Tas.Steeltoe.Core.Web.Controllers
{
    public class HystrixController : Controller
    {
        private readonly HystrixWishlistCommand hystrixWishlistCommand;

        public HystrixController(HystrixWishlistCommand hystrixWishlistCommand)
        {
            this.hystrixWishlistCommand = hystrixWishlistCommand;
        }

        public IActionResult Index()
        {
            ViewBag.Products = hystrixWishlistCommand.GetCustomerWishlist().Result;

            return View();
        }

        public void Delete()
        {
            hystrixWishlistCommand.Crash();
        }
    }
}