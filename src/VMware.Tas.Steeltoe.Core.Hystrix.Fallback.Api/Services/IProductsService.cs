using VMware.Tas.Steeltoe.Core.Hystrix.Fallback.Api.Domain;
using System.Collections.Generic;

namespace VMware.Tas.Steeltoe.Core.Hystrix.Fallback.Api.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> GetProducts();
    }
}