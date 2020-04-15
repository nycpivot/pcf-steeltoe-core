using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pcf.Steeltoe.Dotnet.Core.Hystrix.Api.Domain;
using System;
using System.Collections.Generic;

namespace Pcf.Steeltoe.Dotnet.Core.Hystrix.Api.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IDistributedCache cache;

        public ProductsService(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public static void Load(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var cache = serviceScope.ServiceProvider.GetService<IDistributedCache>();

                if (cache != null)
                {
                    var bytes = cache.Get("Products");
                    if (bytes == null || bytes.Length == 0)
                    {
                        var products = new List<Product>
                        {
                            new Product { Id = 1, Name = "Lugz Drifter Men's Steel Toe Work Boots", Price = 79.99F, Image = "lugz-drifter-mens-steel-toe-work-boots.jpg" },
                            new Product { Id = 2, Name = "Safety Girl II Steel Toe Work Boots - Black", Price = 67.99F, Image = "safety-girl-steel-toe-work-boots-black.jpg" },
                            new Product { Id = 6, Name = "Brahma Men's Kytan Steel Toe Waterproof Hiker Work Boot", Price = 39.47F, Image = "brahma-mens-kytan-steel-toe-waterproof-hiker-work-boot.jpg"}
                        };

                        var json = JsonConvert.SerializeObject(products);

                        cache.SetString("Products", json);
                    }
                }
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            var json = cache.GetString("Products");

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

            return products;
        }
    }
}