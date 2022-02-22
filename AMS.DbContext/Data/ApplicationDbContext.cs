using AMS.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AMS.DbContext.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        { 
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        } 
        public DbSet<ProductGroup> ProductGroup { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Agreement> Agreement { get; set; }
    }
}
