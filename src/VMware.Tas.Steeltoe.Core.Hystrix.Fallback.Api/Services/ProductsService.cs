using System.Collections.Generic;
using VMware.Tas.Steeltoe.Core.Hystrix.Fallback.Api.Context;
using VMware.Tas.Steeltoe.Core.Hystrix.Fallback.Api.Domain;

namespace VMware.Tas.Steeltoe.Core.Hystrix.Fallback.Api.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext productsContext;

        public ProductsService(ProductsContext productsContext)
        {
            this.productsContext = productsContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = productsContext.Products;

            return products;
        }
    }
}