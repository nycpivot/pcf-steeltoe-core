using VMware.Tas.Steeltoe.Core.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VMware.Tas.Steeltoe.Core.Web.Services
{
    public interface IHystrixService
    {
        Task<IEnumerable<ProductViewModel>> GetWishlist();
        Task<IEnumerable<ProductViewModel>> GetProducts();
        void Crash();
    }
}