using Microsoft.AspNetCore.Identity;
using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Services.Ramsay.Services.Ramsay.UserRole.Contracts;
using System.Linq;


namespace Ramsay.Services.Ramsay.Services.Ramsay.UserRole
{
    public class RamsayUserRoles : IRamsayUserRoles
    {

        private RamsayDbContext _context;
        private readonly UserManager<RamsayUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public RamsayUserRoles(RamsayDbContext context,
            UserManager<RamsayUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            this._context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;


        }
        // return this.All().OrderBy(n=>n.Name).Where(n=>n.Id ==_data.UserById._data)

        public IQueryable<IdentityRole> allRoles() => this._roleManager.Roles;

        public IQueryable<IdentityRole> roleById()
        {
            return this.allRoles().OrderBy(id => id.Id);
        }


        //   public IQueryable<RamsayUser> allUsers() => this._userManager.Users;
        //
        //   public IQueryable<RamsayUser> UserById()
        //   {
        //       return this.allUsers().OrderBy(id => id.Id);
        //   }


    }
}
