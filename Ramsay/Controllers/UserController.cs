using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ramsay.Models;
using Ramsay.ViewModels.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ramsay.Controllers
{
    public class UserController : Controller
    {

 


        public IActionResult User(ReceiptViewModel receiptViewModel)
        {
            return View();
        }
    }
}
