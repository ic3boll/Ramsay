using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ramsay.Model;
using Ramsay.ViewModels.Receipt;

namespace Ramsay.Controllers
{
    public class ReceiptController : Controller
    {
        public IActionResult Receipt()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Receipt(ReceiptViewModel receipt)
        {
            var receipts = new Receipt()
            {
                Name = receipt.Name,
                Category = receipt.Category,
                Ingredients = receipt.Ingredients,
                Preparation = receipt.Preparation,
                Description = receipt.Description,
            };
            if (receipt == null)
            {
                return this.View();
            }
            return this.RedirectToAction("User", "User");
        }
    }
}