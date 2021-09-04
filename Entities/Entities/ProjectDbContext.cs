using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Entities.Configuration;

namespace Entities
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSystemRequirements> Requirements { get; set; }


        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration(new ProductConfiguration());
            //builder.ApplyConfiguration(new RequirementsConfiguration());
        }
    }
}
