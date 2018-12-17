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
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
