using Pcf.Steeltoe.Dotnet.Core.Hystrix.Api.Domain;
using System.Collections.Generic;

namespace Pcf.Steeltoe.Dotnet.Core.Hystrix.Api.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> GetProducts();
    }
}