using Steeltoe.Extensions.Configuration.CloudFoundry;
using System.Threading.Tasks;

namespace VMware.Tas.Steeltoe.Core.Web.Services
{
    public interface IEurekaService
    {
        Task<CloudFoundryApplicationOptions> GetAppInfo();
        void Crash();
    }
}