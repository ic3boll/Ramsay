using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Services.Ramsay.Services.Ramsay.Images.Contracts;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts;
using Ramsay.ViewModels;
using Ramsay.ViewModels.Comment;
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
        private readonly RamsayReceiptServices _receiptsService;
        private readonly IMapper _mapper;
        private readonly IImageUploader _imageUploader;

        public ReceiptMannagerController(
            IMapper mapper,
            RamsayReceiptServices receiptsService,
        UserManager<RamsayUser> userManager,
            RamsayDbContext dbContext,
            IImageUploader imageUploader)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _receiptsService = receiptsService;
            _mapper = mapper;
            _imageUploader = imageUploader;
        }
        [HttpPost]
        public async Task<IActionResult> Comment([FromBody]CommentCreateViewModel commentCreateViewModel)
        {
            var userId = _userManager.GetUserId(User);
            var userName = this._userManager.GetUserName(User);
            await _receiptsService.CreateComment(userId, commentCreateViewModel.ReceiptId,commentCreateViewModel.Text);
    
            var commentViewModel = new Comments
            {
                ReceiptId = commentCreateViewModel.ReceiptId,
                Text = commentCreateViewModel.Text,
                UserId = userId
            };
            var receiptViewModel = new CommentCreateViewModel
            {
               ReceiptId = commentCreateViewModel.ReceiptId,
               Text=commentCreateViewModel.Text,
               UserId=userId,
               userName=userName
               
            };
          
         
           _dbContext.SaveChanges();
            var jsonCommentViewModel = JsonConvert.SerializeObject(receiptViewModel);
            return Ok(jsonCommentViewModel);
        }
        [Authorize]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["id"] = id;
            var receiptUserId =_userManager.GetUserId(User);
            var receipts = await this._receiptsService.allReceipts();
            foreach (var item in receipts)
            {
                if(item.UserId == receiptUserId && item.Id==id)
                {
                    var receiptViewModel = this._mapper.Map<ReceiptEditViewModel>(item);
                    return View(receiptViewModel);
                }            
            }
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(ReceiptBindingModel receiptViewModel)
        {
         
            var receiptUserId = _userManager.GetUserId(User);
            var user = await _userManager.GetUserAsync(User);
            var receipts = await this._receiptsService.allReceipts();
            var idCk = TempData["id"];
            var id = Convert.ToInt32(idCk);
            var viewModel = new List<ReceiptEditViewModel>();
            var recToUpdate = _dbContext.Receipts.SingleOrDefault(x => x.Id == id);
            var imageUri = _imageUploader.ImageUpload(receiptViewModel.ImageFile.OpenReadStream());
            foreach (var item in receipts)
            {
                if (idCk.ToString() == item.Id.ToString() && item.UserId == receiptUserId)
                {
                    var receipt = new Receipt()
                    {
                        Id = id,
                        Name = receiptViewModel.Name,
                        Category = receiptViewModel.Category,
                        Ingredients = receiptViewModel.Ingredients,
                        Preparation = receiptViewModel.Preparation,
                        Description = receiptViewModel.Description,
                        User = user,
                        Image=imageUri
                    };
                    _dbContext.Receipts.Remove(recToUpdate);
                    _dbContext.Receipts.Add(receipt);
                }
            }
            _dbContext.SaveChanges();
            return this.RedirectToAction("Userr","User");
        }

    
        [Route("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var users = this._dbContext.Users.ToList();
            var receipts = await this._receiptsService.allReceipts();
            var userId = this._userManager.GetUserId(User);
            var userName = this._userManager.GetUserName(User);
            var coments = await this._receiptsService.Comments();
            var viewModel = new ReceiptViewModel();
            foreach (var item in receipts)
            {
                if (item.Id == id )
                {
                    var ReceiptViewModel = new ReceiptViewModel
                    {
                        Id = item.Id,
                       Name=item.Name,
                       Category=item.Category,
                       Description=item.Description,
                       Image=item.Image,
                       Ingredients=item.Ingredients,
                       Preparation=item.Preparation,
                       
                      
                    };
                    var comments = new List<CommentViewModel>();
                    
                    foreach (var c in coments)
                    {
                       
                        if ( c.ReceiptId==id)
                        {
                            var user=users.Where(u=>u.Id==c.UserId).FirstOrDefault();
                            var cvm = new CommentViewModel();
                            cvm.User = user.UserName;
                            cvm.Text = c.Text;
                            comments.Add(cvm);
                        }
                    }
                    ReceiptViewModel.Comments = comments;
                    ReceiptViewModel.userName = userName;
                    viewModel = ReceiptViewModel;
                }
            }
            return View(viewModel);
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var recToUpdate = _dbContext.Receipts.SingleOrDefault(x => x.Id == id);
            _dbContext.Receipts.Remove(recToUpdate);
            _dbContext.SaveChanges();
            return View();
        }
    }
}
