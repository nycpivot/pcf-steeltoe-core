using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VMware.Tas.Steeltoe.Core.Hystrix.Api.Services;
using Steeltoe.CloudFoundry.Connector.Redis;
using Steeltoe.Discovery.Client;
using Microsoft.Extensions.Hosting;

namespace VMware.Tas.Steeltoe.Core.Hystrix.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDiscoveryClient(Configuration);

            services.AddSingleton<IProductsService, ProductsService>();

            services.AddDistributedRedisCache(Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDiscoveryClient();

            app.UseMvc();

            ProductsService.Load(app.ApplicationServices);
        }
    }
}