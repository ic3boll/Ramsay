using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts;
using Ramsay.ViewModels;
using Ramsay.ViewModels.Receipt;

namespace Ramsay.Controllers
{
    public class HomeController : Controller
    {

        private RamsayDbContext context;

        private readonly RamsayReceiptServices _receiptsService;
        private readonly IMapper _mapper;


        public HomeController(RamsayDbContext dbContext,
            RamsayReceiptServices receiptServices,
            IMapper mapper)
        {
            this._mapper = mapper;
            this._receiptsService = receiptServices;
            this.context = dbContext;
        }


        public IActionResult Index()
        {
            var receipts = this._receiptsService.allReceipts();
            var viewModel = new List<ReceiptViewModel>();

            foreach (var item in receipts)
            {
                var receiptViewModel = this._mapper.Map<ReceiptViewModel>(item);
                viewModel.Add(receiptViewModel);
            }

            return View(viewModel);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
