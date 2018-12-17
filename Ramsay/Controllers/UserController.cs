using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ramsay.Data;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts.Contracts;
using Ramsay.ViewModels.Receipt;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ramsay.Controllers
{
    public class UserController : Controller
    {
        
        private readonly RamsayReceiptServices _receiptsService;
        private readonly IMapper _mapper;
       


        public UserController(
            IMapper mapper,
            RamsayReceiptServices receiptsService)
        {
            this._mapper = mapper;
           this._receiptsService = receiptsService;
           
        }


        public IActionResult User()
        {
            var receipts = this._receiptsService.allReceipts();
            var viewModel = new List<ReceiptViewModel>();

            foreach (var item in receipts)
            {
                var receiptViewModel = this._mapper.Map<ReceiptViewModel>(item);
                viewModel.Add(receiptViewModel);
            }

            return View(viewModel);
        }
    }
}
