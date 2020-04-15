using Microsoft.EntityFrameworkCore;
using VMware.Tas.Steeltoe.Core.Hystrix.Fallback.Api.Domain;

namespace VMware.Tas.Steeltoe.Core.Hystrix.Fallback.Api.Context
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}