using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Timers;

namespace VMware.Tas.Steeltoe.Core.Web.Extensions
{
    public static class ConfigurationExtensions
    {
        private static readonly List<Timer> Timers = new List<Timer>();

        public static IConfigurationRoot AutoRefresh(this IConfigurationRoot config, TimeSpan timeSpan)
        {
            var myTimer = new Timer()
            {
                Interval = 10000,
                Enabled = true
            };

            myTimer.Elapsed += (sender, args) => config.Reload();

            Timers.Add(myTimer);

            return config;
        }
    }
}