using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts;
using Ramsay.Services.Ramsay.Services.Ramsay.UserRole;
using Ramsay.ViewModels.Receipt;
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
        private readonly RamsayReceiptServices _receiptsService;
        private readonly IMapper _mapper;

        public ReceiptMannagerController(
            IMapper mapper,
            RamsayReceiptServices receiptsService,
            RoleManager<IdentityRole> roleManager,
        UserManager<RamsayUser> userManager,
            RamsayDbContext dbContext,
            RamsayUserRoles ramsayUserRoles)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _roleManager = roleManager;
            _ramsayUserRoles = ramsayUserRoles;
            _receiptsService = receiptsService;
            _mapper = mapper;
        }

        [Authorize]
        [Route("Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            TempData["id"] = id;
            return this.View();
        }

        [Authorize]
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(ReceiptEditViewModel receiptViewModel)
        {
            var user = await _userManager.GetUserAsync(User);
            var receipts = this._receiptsService.allReceiptsById();
            var idCk = TempData["id"];
            var id = Convert.ToInt32(idCk);
            var viewModel = new List<ReceiptEditViewModel>();
            var recToUpdate = _dbContext.Receipts.SingleOrDefault(x => x.Id == id);
            foreach (var item in receipts)
            {
                if (idCk.ToString() == item.Id.ToString())
                {

                    var receipt = new Receipt()
                    {
                        Id = id,
                        Name = receiptViewModel.Name,
                        Category = receiptViewModel.Category,
                        Ingredients = receiptViewModel.Ingredients,
                        Preparation = receiptViewModel.Preparation,
                        Description = receiptViewModel.Description,
                        User = user
                       
                    };

                    _dbContext.Receipts.Remove(recToUpdate);
                    _dbContext.Receipts.Add(receipt);
                }
            }
            _dbContext.SaveChanges();
            return this.RedirectToAction("Userr","User");
        }

        [Authorize]
        [Route("Details")]
        public async Task<IActionResult> Details(string name)
        {
            var receipts = this._receiptsService.allReceipts();

            var viewModel = new List<ReceiptViewModel>();

            foreach (var item in receipts)
            {
                if (item.Name == name)
                {
                    var receiptViewModel = this._mapper.Map<ReceiptViewModel>(item);
                    viewModel.Add(receiptViewModel);
                }
            }

            return View(viewModel);
        }
   
        [Authorize]
        public ActionResult Delete(string name)
        {
            var idCk = TempData["id"];
            var id = Convert.ToInt32(idCk);
            var recToUpdate = _dbContext.Receipts.SingleOrDefault(x => x.Id == id);
            _dbContext.Receipts.Remove(recToUpdate);
            _dbContext.SaveChanges();
            return View();
        }
    }
}
