using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestingDbContextScope.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(): base("ProductDbConnectionString") // base(CmsdbConnectionString())
        {
            Database.SetInitializer<ProductDbContext>(new MigrateDatabaseToLatestVersion<ProductDbContext,
                TestingDbContextScope.Data.Migrations.Configuration>());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
    }
}
