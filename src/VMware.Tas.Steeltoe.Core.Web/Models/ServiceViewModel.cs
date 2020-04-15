using System.Collections.Generic;

namespace VMware.Tas.Steeltoe.Core.Web.Models
{
    public class ServiceViewModel
    {
        public string Label { get; set; }
        public string Name { get; set; }
        public string Plan { get; set; }

        public Dictionary<string, string> Credentials { get; set; } = new Dictionary<string, string>();
    }
}