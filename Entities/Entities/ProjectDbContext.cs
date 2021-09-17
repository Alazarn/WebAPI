using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Entities.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Entities
{
    public class ProjectDbContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSystemRequirements> Requirements { get; set; }


        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.ApplyConfiguration(new ProductConfiguration());
            //builder.ApplyConfiguration(new RequirementsConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
