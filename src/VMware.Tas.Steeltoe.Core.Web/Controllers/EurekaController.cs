using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VMware.Tas.Steeltoe.Core.Web.Services;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using System;
using System.Collections.Generic;
using System.Text;

namespace VMware.Tas.Steeltoe.Core.Web.Controllers
{
    public class EurekaController : Controller
    {
        private readonly CloudFoundryApplicationOptions appOptions;
        private readonly IEurekaService eurekaService;

        public EurekaController(
            IOptions<CloudFoundryApplicationOptions> appOptions,
            IEurekaService eurekaService)
        {
            this.appOptions = appOptions.Value;
            this.eurekaService = eurekaService;
        }

        public IActionResult Index()
        {
            ViewBag.ClientIP = appOptions.InstanceIP;

            var serviceOptions = eurekaService.GetAppInfo().Result;

            var usedIPs = new List<string>();
            foreach (var ip in HttpContext.Session.Keys)
            {
                if (ip != serviceOptions.InstanceIP)
                {
                    usedIPs.Add(ip);
                }
            }

            ViewBag.UsedIPs = usedIPs;

            HttpContext.Session.SetString(serviceOptions.InstanceIP, serviceOptions.InstanceIP);

            ViewBag.ServiceIP = serviceOptions.InstanceIP;
            //ViewBag.ServerName = serviceOptions.ServerName;

            return View();
        }

        public void Delete()
        {
            var bytes3 = Encoding.UTF8.GetBytes("3...");
            var bytes2 = Encoding.UTF8.GetBytes("2...");
            var bytes1 = Encoding.UTF8.GetBytes("1");

            Console.WriteLine("THIS APP WILL SELF-DESTRUCT IN...");
            Console.OpenStandardError().Write(bytes3, 0, bytes3.Length);
            Console.OpenStandardError().Write(bytes2, 0, bytes2.Length);
            Console.OpenStandardError().Write(bytes1, 0, bytes1.Length);

            eurekaService.Crash();
        }
    }
}