using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Ramsay.Data;
using Ramsay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ramsay.Middlewares
{
    public class DataMiddleware
    {

        private readonly RequestDelegate next;
  
    

        public DataMiddleware(RequestDelegate next
          )
        {
            this.next = next;
         
        }

        public async Task InvokeAsync(
           HttpContext context,
           RamsayDbContext dbContext,
            UserManager<RamsayUser> usermanager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!dbContext.Roles.Any() && usermanager.Users.Any())
            {
                await this.SeedRoles(usermanager, roleManager);
            }

            await this.next(context);

        }

        private async Task SeedRoles(
             UserManager<RamsayUser> usermanager,
             RoleManager<IdentityRole> roleManager)
        {
            var result = await roleManager.CreateAsync(new IdentityRole("Administrator"));
            if (usermanager.Users.Any())
            {
                var firstUser = usermanager.Users.FirstOrDefault();
                await usermanager.AddToRoleAsync(firstUser, "Administrator");
            }
        }
    }
}