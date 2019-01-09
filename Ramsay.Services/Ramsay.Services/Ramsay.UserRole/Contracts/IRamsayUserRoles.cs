using Microsoft.AspNetCore.Identity;
using Ramsay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramsay.Services.Ramsay.Services.Ramsay.UserRole.Contracts
{
   public interface IRamsayUserRoles
    {
        Task<IQueryable<IdentityUser>> users();
            IQueryable<IdentityRole> allRoles();
        IQueryable<IdentityRole> roleById();

    }
}
