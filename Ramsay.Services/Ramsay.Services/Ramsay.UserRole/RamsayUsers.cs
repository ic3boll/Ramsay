using Microsoft.AspNetCore.Identity;
using Ramsay.Models.Interfaces.Repositories;
using Ramsay.Services.Ramsay.Services.Ramsay.UserRole.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramsay.Services.Ramsay.Services.Ramsay.UserRole
{
    public class RamsayUsers : IRamsayUsers
    {

        private readonly IRepository<IdentityUser> _userRepository;

        public RamsayUsers(IRepository<IdentityUser> userRepository)
        {
            this._userRepository = userRepository;
        }

        public int getCount()
        {
            return this._userRepository.All().Count();
        }

    
    }
}
