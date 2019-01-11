using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ramsay.Areas.ViewModels;
using Ramsay.Data;
using Ramsay.Models;
using Ramsay.ViewModels.Account;

namespace Ramsay.Areas.Identity.Controllers
{
    [Authorize]
    [Area("Identity")]
    public class ManageController : Controller
    {
        private RamsayDbContext _context;
        private readonly UserManager<RamsayUser> _userManager;
        private readonly SignInManager<RamsayUser> _signInManager;
        private readonly ILogger<ChangePasswordViewModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly RamsayDbContext _ramsayDbContext;

        public ManageController(RamsayDbContext context,
            UserManager<RamsayUser> userManager,
            SignInManager<RamsayUser> signInManager,
             ILogger<ChangePasswordViewModel> logger,
             RoleManager<IdentityRole> roleManager,
             RamsayDbContext ramsayDbContext)
        {
            this._context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._logger = logger;
            this._roleManager = roleManager;
            this._ramsayDbContext = ramsayDbContext;

        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Administrator"))
            {
                var getUser = await this._userManager.GetUserAsync(User);

                var user = new AccountManageViewModel
                {
                    Username = getUser.UserName,
                    Id = getUser.Id

                };
                var AccountViewModel = new AccountManageViewModel();

                AccountViewModel = user;
                return View(AccountViewModel);
            }
            return this.RedirectToAction("Userr", "User");
        }
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var model = new ChangePasswordViewModel { StatusMessage = StatusMessage };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("User changed their password successfully.");
            StatusMessage = "Your password has been changed.";

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateRoles()
        {
           
            if (User.IsInRole("Administrator"))
            {
                return View();
            }
            return this.RedirectToAction("Userr", "User");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoles(CreateRoleViewModel createRoleViewModel)
        {
            var role = createRoleViewModel.CreateRole;
            if (!this._ramsayDbContext.Roles.Any(r => r.Name == role))
            {
               await this._roleManager.CreateAsync(new IdentityRole(role));

            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SetRoles()
        {        
            var result = new List<SetRoleViewModel>();
            var roles =  this._ramsayDbContext.Roles.ToList();
            var users = this._ramsayDbContext.Users.ToList();
            var userRoles = this._ramsayDbContext.UserRoles.ToList();

            foreach (var ur in userRoles)
            {
                var roleId = ur.RoleId;
                var userId = ur.UserId;

                foreach (var user in users)
                {
                    var userData = new SetRoleViewModel
                    {
                        userName = user.UserName
                    };
            
                    if (user.Id == userId)
                    {
                        foreach (var role in roles)
                        {
                            if (role.Id == roleId)
                            {
                                var userRoleList = new SetRoleViewModel
                                {
                                    roles = role.Name
                                };
                            }
                            userData.roles = role.Name;
                        }
                        
                    }
                    result.Add(userData);
                }
            }
            return View(result);
        }
         [HttpPost]
         public async Task<IActionResult> SetRoles(string role)
         {
             return View();
         } 
    }
}