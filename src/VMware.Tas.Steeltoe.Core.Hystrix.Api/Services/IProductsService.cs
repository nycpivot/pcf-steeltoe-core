using VMware.Tas.Steeltoe.Core.Hystrix.Api.Domain;
using System.Collections.Generic;

namespace VMware.Tas.Steeltoe.Core.Hystrix.Api.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> GetProducts();
    }
}