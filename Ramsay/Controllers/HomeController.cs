using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts;
using Ramsay.ViewModels.Receipt;
using X.PagedList;
namespace Ramsay.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        private RamsayDbContext _context;
        private readonly RamsayReceiptServices _receiptsService;
        private readonly IMapper _mapper;


        public HomeController(RamsayDbContext dbContext,
            RamsayReceiptServices receiptServices,
            IMapper mapper)
        {
            this._mapper = mapper;
            this._receiptsService = receiptServices;
            this._context = dbContext;
        }


        public async Task<IActionResult> Index(int? page)
        {
            var users = await this._context.Users.ToListAsync();

            var receipts =await this._receiptsService.allReceipts();
            var viewModel = new List<ReceiptEditViewModel>();

            foreach (var item in receipts)
            {
                var receiptViewModel = this._mapper.Map<ReceiptEditViewModel>(item);
                viewModel.Add(receiptViewModel);
            }
            var nextPage = page ?? 1;
            var pagedViewModels = viewModel.ToPagedList(nextPage, 8);


            return View(pagedViewModels);


        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
