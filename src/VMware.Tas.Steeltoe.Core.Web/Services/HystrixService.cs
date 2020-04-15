using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VMware.Tas.Steeltoe.Core.Web.Models;
using Steeltoe.Common.Discovery;

namespace VMware.Tas.Steeltoe.Core.Web.Services
{
    public class HystrixService : IHystrixService
    {
        private readonly HttpClient http;

        public HystrixService(IDiscoveryClient client)
        {
            var handler = new DiscoveryHttpClientHandler(client);

            this.http = new HttpClient(handler, false);
        }

        public async Task<IEnumerable<ProductViewModel>> GetWishlist()
        {
            var url = "http://tas-steeltoe-core-hystrix-api/default";

            var response = http.GetAsync(url).Result;
            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<IEnumerable<ProductViewModel>>(json);

            return model;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var url = "http://tas-steeltoe-core-hystrix-fallback-api/default";

            var response = http.GetAsync(url).Result;
            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<IEnumerable<ProductViewModel>>(json);

            return model;
        }

        public void Crash()
        {
            var url = "http://tas-steeltoe-core-hystrix-api/default";

            http.DeleteAsync(url);
        }
    }
}