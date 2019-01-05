using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ramsay.Models;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts;
using Ramsay.ViewModels.Receipt;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace Ramsay.Controllers
{
    [Authorize]  
    public class UserController : Controller
    {
        
        private readonly RamsayReceiptServices _receiptsService;
    
        private readonly IMapper _mapper;
        private SignInManager<RamsayUser> _SignIn;



        public UserController(
            IMapper mapper,
        RamsayReceiptServices receiptsService,
        SignInManager<RamsayUser> SignIn)
        {
            this._mapper = mapper;
            this._receiptsService = receiptsService;

            this._SignIn = SignIn;
        }

        [Route("User")]
        public async Task<IActionResult> Userr(int? page)
        {
            var receipts = this._receiptsService.allReceipts();
           
            var viewModel = new List<ReceiptEditViewModel>();

            var userId = _SignIn.UserManager.GetUserId(User);

           
            foreach (var item in receipts)
            {
                if (item.UserId == userId)
                {
                    var receiptViewModel = this._mapper.Map<ReceiptEditViewModel>(item);
                    viewModel.Add(receiptViewModel);
                }
            }
            var nextPage = page ?? 1;
            var pagedViewModels = viewModel.ToPagedList(nextPage, 4);


            return View(pagedViewModels);
        }
    }
}
