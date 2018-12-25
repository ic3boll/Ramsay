using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ramsay.Data;

using Ramsay.Models;
using Ramsay.Services.Ramsay.Services.Ramsay.UserRole;
using Ramsay.ViewModels.Receipt;

namespace Ramsay.Controllers
{
    [Route("Create-Receipts")]
    public class ReceiptController : Controller
    {

        private readonly UserManager<RamsayUser> _userManager;
        private readonly RamsayDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly RamsayUserRoles _ramsayUserRoles;



        public ReceiptController(
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
        //      /Create-Receipts

        public IActionResult Receipt()
        {
            return View();
        }

        [HttpPost]
        //Proba
        public async Task<IActionResult> Receipt(ReceiptViewModel receiptViewModel)
        {
            var user = await _userManager.GetUserAsync(User);
            var role = _ramsayUserRoles.roleById();
            var roleId = role.FirstOrDefault();
            var roleName = await _roleManager.GetRoleNameAsync(roleId);
            var UserInRole = await _userManager.IsInRoleAsync(user, roleName);
            if (receiptViewModel.Description == null)
            {
                return this.RedirectToAction("Receipt", "Receipt");
            }
            else
            {
                if (UserInRole == true)
                {
                    var receipt = new Receipt()
                    {
                        Name = receiptViewModel.Name,
                        Category = receiptViewModel.Category,
                        Ingredients = receiptViewModel.Ingredients,
                        Preparation = receiptViewModel.Preparation,
                        Description = receiptViewModel.Description,
                        User = user

                    };
                    _dbContext.Add(receipt);
                    _dbContext.SaveChanges();
                    return this.RedirectToAction("Home", "Index");
                }
                else
                {
                    var receipt = new Receipt()
                    {
                        Name = receiptViewModel.Name,
                        Category = receiptViewModel.Category,
                        Ingredients = receiptViewModel.Ingredients,
                        Preparation = receiptViewModel.Preparation,
                        Description = receiptViewModel.Description,
                        User = user

                    };
                    _dbContext.Add(receipt);
                    _dbContext.SaveChanges();
                }

                return this.RedirectToAction("User", "Userr");
            }
        }
    }
}