using Microsoft.AspNetCore.Identity;
using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Services.Ramsay.Services.Ramsay.UserRole.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Ramsay.Services.Ramsay.Services.Ramsay.UserRole
{
    public class RamsayUserRoles : IRamsayUserRoles
    {

        private readonly RamsayDbContext _context;
        
        private readonly UserManager<RamsayUsers> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public RamsayUserRoles(RamsayDbContext context,
            UserManager<RamsayUsers> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            this._context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;


        }

        public IQueryable<IdentityRole> allRoles() => this._roleManager.Roles;

        public IQueryable<IdentityRole> roleById()
        {
         
            return this.allRoles().OrderBy(id => id.Id);
        }

      

        Task<IQueryable<IdentityUser>> IRamsayUserRoles.users()
        {
            throw new System.NotImplementedException();
        }
    }
}
