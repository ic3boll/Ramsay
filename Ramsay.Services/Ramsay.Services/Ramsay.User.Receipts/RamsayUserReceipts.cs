using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Services.Ramsay.Services.Ramsay.User.Receipts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ramsay.Services.Ramsay.Services.Ramsay.User.Receipts
{
    public class RamsayUserReceipts : IRamsayUserReceipts
    {

        private RamsayDbContext _context;
        private readonly UserManager<RamsayUser> _userManager;
        private readonly IdentityUser _identityUser;

        public RamsayUserReceipts(RamsayDbContext context,
            UserManager<RamsayUser> userManager,
            IdentityUser identityUser)
        {
            this._context = context;
            this._userManager = userManager;
            this._identityUser = identityUser;
        }

        public IQueryable<RamsayUser> allUsers() => this._userManager.Users;

        public IQueryable<RamsayUser> UserById()
        {
            return this.allUsers().OrderBy(id => id.Id);
        }


   
    }
}
