using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Steeltoe.Common.Discovery;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace VMware.Tas.Steeltoe.Core.Web.Services
{
    public class EurekaService : IEurekaService
    {
        private readonly HttpClient http;

        public EurekaService(IDiscoveryClient client)
        {
            var handler = new DiscoveryHttpClientHandler(client);

            this.http = new HttpClient(handler, false)
            {
                BaseAddress = new Uri("http://pcf-steeltoe-dotnet-core-eureka-api/app")
            };
        }

        public async Task<CloudFoundryApplicationOptions> GetAppInfo()
        {
            var response = http.GetAsync(String.Empty).Result;
            var json = await response.Content.ReadAsStringAsync();

            var appOptions = JsonConvert.DeserializeObject<CloudFoundryApplicationOptions>(json);

            return appOptions;
        }

        public void Crash()
        {
            http.DeleteAsync(String.Empty);
        }
    }
}