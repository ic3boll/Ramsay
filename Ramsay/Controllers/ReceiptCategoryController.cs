using AutoMapper;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Models.Enums;
using Ramsay.Services;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts;
using Ramsay.ViewModels.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Ramsay.Controllers
{
        [Route("Category/[action]")]
    public class ReceiptCategoryController : Controller
    {
        private readonly RamsayReceiptServices _receiptsService;
        private readonly IMapper _mapper;

        public ReceiptCategoryController(
            IMapper mapper,
            RamsayReceiptServices receiptsService
           )
        {
            _receiptsService = receiptsService;
            _mapper = mapper;
        }

        public async Task<IActionResult> BreakFast(int? page)
        {
            var receipts = await this._receiptsService.allReceipts();
            var viewModel = new List<ReceiptEditViewModel>();
            foreach (var item in receipts)
            {
                if (item.Category.Equals(ReceiptCategory.Breakfast))
                {
                    var receiptViewModel = this._mapper.Map<ReceiptEditViewModel>(item);
                    viewModel.Add(receiptViewModel);
                }
               
            }
            var nextPage = page ?? 1;
            var pagedViewModels = viewModel.ToPagedList(nextPage, 4);


            return View(pagedViewModels);
        }

        public async Task<IActionResult> Brunch(int? page)
        {
            var receipts = await this._receiptsService.allReceipts();
            var viewModel = new List<ReceiptEditViewModel>();
            foreach (var item in receipts)
            {
                if (item.Category.Equals(ReceiptCategory.Brunch))
                {
                    var receiptViewModel = this._mapper.Map<ReceiptEditViewModel>(item);
                    viewModel.Add(receiptViewModel);
                }

            }
            var nextPage = page ?? 1;
            var pagedViewModels = viewModel.ToPagedList(nextPage, 4);


            return View(pagedViewModels);
        }

        public async Task<IActionResult> Dessert(int? page)
        {
            var receipts = await this._receiptsService.allReceipts();
            var viewModel = new List<ReceiptEditViewModel>();
            foreach (var item in receipts)
            {
                if (item.Category.Equals(ReceiptCategory.Dessert))
                {
                    var receiptViewModel = this._mapper.Map<ReceiptEditViewModel>(item);
                    viewModel.Add(receiptViewModel);
                }

            }
            var nextPage = page ?? 1;
            var pagedViewModels = viewModel.ToPagedList(nextPage, 4);


            return View(pagedViewModels);
        }

        public async Task<IActionResult> Dinner(int? page)
        {
            var receipts = await this._receiptsService.allReceipts();
            var viewModel = new List<ReceiptEditViewModel>();
            foreach (var item in receipts)
            {
                if (item.Category.Equals(ReceiptCategory.Dinner))
                {
                    var receiptViewModel = this._mapper.Map<ReceiptEditViewModel>(item);
                    viewModel.Add(receiptViewModel);
                }

            }
            var nextPage = page ?? 1;
            var pagedViewModels = viewModel.ToPagedList(nextPage, 4);


            return View(pagedViewModels);
        }

        public async Task<IActionResult> Lunch(int? page)
        {
            var receipts = await this._receiptsService.allReceipts();
            var viewModel = new List<ReceiptEditViewModel>();
            foreach (var item in receipts)
            {
                if (item.Category.Equals(ReceiptCategory.Lunch))
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
