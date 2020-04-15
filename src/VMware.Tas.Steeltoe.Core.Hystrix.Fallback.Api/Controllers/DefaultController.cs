using Microsoft.AspNetCore.Mvc;
using VMware.Tas.Steeltoe.Core.Hystrix.Fallback.Api.Services;

namespace VMware.Tas.Steeltoe.Core.Hystrix.Fallback.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class DefaultController : Controller
    {
        private readonly IProductsService productsService;

        public DefaultController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Get()
        {
            var products = productsService.GetProducts();

            return Ok(products);
        }
    }
}