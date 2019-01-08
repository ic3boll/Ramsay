using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ramsay.Data;

using Ramsay.Models;
using Ramsay.Services;
using Ramsay.Services.Ramsay.Services.Ramsay.UserRole;
using Ramsay.ViewModels;

namespace Ramsay.Controllers
{
    [Route("Create-Receipts")]
    public class ReceiptController : Controller
    {
        private readonly UserManager<RamsayUser> _userManager;
        private readonly RamsayDbContext _dbContext;
        private readonly IImageUploader _imageUploader;

        public ReceiptController(
      
        UserManager<RamsayUser> userManager,
            RamsayDbContext dbContext,
            IImageUploader imageUploader)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _imageUploader = imageUploader;
        }
        //      /Create-Receipts
        [Authorize] 
        public IActionResult Receipt()
        {
            return View();
        }

        [HttpPost]
        //Create Receipts
        public async Task<IActionResult> Receipt(ReceiptBindingModel receiptViewModel)
        {
            var user = await _userManager.GetUserAsync(User); 
            var imageUri = _imageUploader.ImageUpload(receiptViewModel.ImageFile.OpenReadStream());

                    var receipt = new Receipt()
                    {
                        Name = receiptViewModel.Name,
                        Category = receiptViewModel.Category,
                        Ingredients = receiptViewModel.Ingredients,
                        Preparation = receiptViewModel.Preparation,
                        Description = receiptViewModel.Description,
                        User = user,
                        Image= imageUri
                    };
                    _dbContext.Add(receipt);    
                    _dbContext.SaveChanges();
                    return this.RedirectToAction("Userr", "User");
            }
        }
    }
