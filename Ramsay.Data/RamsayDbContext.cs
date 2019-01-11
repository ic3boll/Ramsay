using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Ramsay.Models;

namespace Ramsay.Data
{
    public class RamsayDbContext : IdentityDbContext<RamsayUser>
    {
 

        public RamsayDbContext(DbContextOptions<RamsayDbContext> options)
            : base(options)
        {
            
        }
        
        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Comments> Comments { get; set; }
         

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

    }
}
