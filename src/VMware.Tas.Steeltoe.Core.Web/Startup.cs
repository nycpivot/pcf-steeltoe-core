using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Steeltoe.CircuitBreaker.Hystrix;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using System;
using VMware.Tas.Steeltoe.Core.Web.Commands;
using VMware.Tas.Steeltoe.Core.Web.Extensions;
using VMware.Tas.Steeltoe.Core.Web.Models;
using VMware.Tas.Steeltoe.Core.Web.Services;

namespace VMware.Tas.Steeltoe.Core.Web
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
            ((IConfigurationRoot)Configuration).AutoRefresh(TimeSpan.FromSeconds(10));

            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            //configuration
            services.AddOptions();
            services.ConfigureCloudFoundryOptions(Configuration);
            //services.ConfigureCloudFoundryService<ConfigServerOptions>(Configuration, "pcf-config-server");
            services.ConfigureCloudFoundryService<CupsOptions>(Configuration, "tas-cups-database");

            //discovery
            services.AddDiscoveryClient(Configuration);

            //hystrix/circuit breaker
            services.AddHystrixCommand<HystrixWishlistCommand>(
                "tas-steeltoe-core-web", Configuration);

            services.AddSingleton<IEurekaService, EurekaService>();
            services.AddSingleton<IHystrixService, HystrixService>();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = new TimeSpan(0, 30, 0);
            });

            // services.UseBreadcrumbs(GetType().Assembly);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseDiscoveryClient();
        }
    }
}
