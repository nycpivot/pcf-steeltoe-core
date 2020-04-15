using VMware.Tas.Steeltoe.Core.Web.Models;
using VMware.Tas.Steeltoe.Core.Web.Services;
using Steeltoe.CircuitBreaker.Hystrix;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VMware.Tas.Steeltoe.Core.Web.Commands
{
    public class HystrixWishlistCommand : HystrixCommand<IEnumerable<ProductViewModel>>
    {
        private readonly IHystrixService hystrixService;

        public HystrixWishlistCommand(
            IHystrixCommandOptions hystrixCommandOptions,
            IHystrixService hystrixService) : base(hystrixCommandOptions)
        {
            this.hystrixService = hystrixService;
        }

        public async Task<IEnumerable<ProductViewModel>> GetCustomerWishlist()
        {
            return await ExecuteAsync();
        }
        
        protected override async Task<IEnumerable<ProductViewModel>> RunAsync()
        {
            var result = await hystrixService.GetWishlist();

            return result;
        }

        protected override async Task<IEnumerable<ProductViewModel>> RunFallbackAsync()
        {
            var products = await hystrixService.GetProducts();

            return products;
        }

        public void Crash()
        {
            hystrixService.Crash();
        }
    }
}