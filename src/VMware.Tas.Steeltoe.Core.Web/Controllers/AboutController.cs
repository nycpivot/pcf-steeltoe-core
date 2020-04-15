using Microsoft.AspNetCore.Mvc;

namespace VMware.Tas.Steeltoe.Core.Web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}