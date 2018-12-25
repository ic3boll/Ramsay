using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Services.Ramsay.Services.Ramsay.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ramsay.Controllers
{
    public class ReceiptMannagerController : Controller
    {
        private readonly UserManager<RamsayUser> _userManager;
        private readonly RamsayDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly RamsayUserRoles _ramsayUserRoles;



        public ReceiptMannagerController(
            RoleManager<IdentityRole> roleManager,
        UserManager<RamsayUser> userManager,
            RamsayDbContext dbContext,
            RamsayUserRoles ramsayUserRoles)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _roleManager = roleManager;
            _ramsayUserRoles = ramsayUserRoles;

        }
        [Authorize]
        public ActionResult Edit(string name)
        {

            return View(name);
        }

        [Authorize]
        [Route("Details")]
        public async Task<IActionResult> Details(string name)
        {
            ViewBag.Name = name;
            return View(ViewBag);
        }
   
        [Authorize]
        public ActionResult Delete(string name)
        {

            return View(name);
        }
    }
}
