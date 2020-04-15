using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace VMware.Tas.Steeltoe.Core.Web.Models
{
    public class ConfigServerOptions : AbstractServiceOptions
    {
        public Credentials Credentials { get; set; }
    }

    public class Credentials
    {
        public string Uri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AccessTokenUri { get; set; }
    }
}