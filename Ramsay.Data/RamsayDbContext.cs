using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ramsay.Model;
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
    
    }
}
