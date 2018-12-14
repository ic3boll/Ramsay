using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ramsay.Data;
using Ramsay.Model;
using Ramsay.Models;
using Ramsay.ViewModels.Account;
using Ramsay.ViewModels.Receipt;

namespace Ramsay.Controllers
{
    public class ReceiptController : Controller
    {

        private readonly UserManager<RamsayUser> _userManager;
        private readonly RamsayDbContext _dbContext;

    
        public ReceiptController(UserManager<RamsayUser> userManager,
            RamsayDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public IActionResult Receipt()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Receipt(ReceiptViewModel receiptViewModel)
        {
            var user = await _userManager.GetUserAsync(User);
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

            return this.RedirectToAction("User", "User");
        }
    }
}