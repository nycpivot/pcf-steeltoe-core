using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VMware.Tas.Steeltoe.Core.Web.Models;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using System.Collections.Generic;

namespace VMware.Tas.Steeltoe.Core.Web.Controllers.Config
{
    public class OptionsController : Controller
    {
        private readonly CloudFoundryApplicationOptions appOptions;
        private readonly CloudFoundryServicesOptions serviceOptions;
        private readonly CupsOptions cupsOptions;

        public OptionsController(
            IOptions<CloudFoundryApplicationOptions> appOptions,
            IOptions<CloudFoundryServicesOptions> serviceOptions,
            IOptionsSnapshot<CupsOptions> cupsOptions)
        {
            this.appOptions = appOptions.Value;
            this.serviceOptions = serviceOptions.Value;

            this.cupsOptions = cupsOptions.Get("pcf-cups-database");
        }

        public IActionResult Index()
        {
            //read app settings
            ViewBag.ApplicationId = appOptions.ApplicationId;
            ViewBag.ApplicationName = appOptions.ApplicationName;
            ViewBag.Uri = appOptions.ApplicationUris != null
                && appOptions.ApplicationUris.Length > 0 ? appOptions.ApplicationUris[0] : "";
            ViewBag.ApplicationVersion = appOptions.ApplicationVersion;
            ViewBag.CloudFoundryApi = appOptions.CF_Api;
            ViewBag.DiskLimit = appOptions.DiskLimit;
            ViewBag.InstanceIndex = appOptions.InstanceIndex;
            ViewBag.InstanceId = appOptions.InstanceId;
            ViewBag.InstanceIp = appOptions.InstanceIP;
            ViewBag.InternalIp = appOptions.InternalIP;
            ViewBag.Limits = appOptions.Limits;
            ViewBag.MemoryLimit = appOptions.MemoryLimit;
            ViewBag.Name = appOptions.Name;
            ViewBag.Port = appOptions.Port;
            ViewBag.SpaceId = appOptions.SpaceId;
            ViewBag.SpaceName = appOptions.SpaceName;
            ViewBag.Start = appOptions.Start;
            ViewBag.Uris = appOptions.Uris;
            ViewBag.Version = appOptions.Version;

            var services = new List<ServiceViewModel>();

            //read service settings
            if (serviceOptions.ServicesList != null && serviceOptions.ServicesList.Count > 0)
            {
                foreach (var service in serviceOptions.ServicesList)
                {
                    var serviceViewModel = new ServiceViewModel()
                    {
                        Label = service.Label,
                        Name = service.Name,
                        Plan = service.Plan
                    };

                    foreach(var credential in service.Credentials)
                    {
                        if(credential.Key == "client_secret" || credential.Key == "password")
                        {
                            serviceViewModel.Credentials.Add("Client Secret", credential.Value.Value);
                        }
                    }

                    services.Add(serviceViewModel);
                }
            }

            //read cups settings into abstract service options
            var cups = new CupsViewModel
            {
                Provider = this.cupsOptions.Credentials.Provider,
                Server = this.cupsOptions.Credentials.Server,
                Port = this.cupsOptions.Credentials.Port,
                Database = this.cupsOptions.Credentials.Database,
                UserId = this.cupsOptions.Credentials.UserId,
                Password = this.cupsOptions.Credentials.Password
            };

            ViewBag.Services = services;
            ViewBag.Cups = cups;

            return View();
        }
    }
}