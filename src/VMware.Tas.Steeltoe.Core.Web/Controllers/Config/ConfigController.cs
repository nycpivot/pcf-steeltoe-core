using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace VMware.Tas.Steeltoe.Core.Web.Controllers.Config
{
    public class ConfigController : Controller
    {
        private readonly IConfiguration configuration;

        public ConfigController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.ConnectionString = configuration["ConnectionString"];
            ViewBag.UserName = configuration["UserName"];
            ViewBag.Password = configuration["Password"];

            return View();
        }
    }
}