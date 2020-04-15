using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace VMware.Tas.Steeltoe.Core.Web.Models
{
    public class CupsOptions : AbstractServiceOptions
    {
        public CupsOptions() { }
        public CupsOptionsCredentials Credentials { get; set; }
    }
}