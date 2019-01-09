using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Models.Enums;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Ramsay.Services.Ramsay.Services.Ramsay.Receipts
{
    public class RamsayReceiptServices : IRamsayReceiptsServices
    {

        
        private  RamsayDbContext _context;
   

        public RamsayReceiptServices(RamsayDbContext context)
        {
            this._context = context;
        
        }

        public async Task<IQueryable<Receipt>> All() => this._context.Receipts;
        public async Task<IQueryable<Receipt>> allReceipts()
        {
            return await this.All();
        }

        public async Task<IQueryable<Comments>> Allcomments() => this._context.Comments;

        public async Task<IQueryable<Comments>> Comments()
        {
            return await this.Allcomments();
        }
        public async Task<IQueryable<Comments>> AllcommentsId(int id) => this._context.Comments.OrderBy(ri=>ri.ReceiptId==id);
   

        public async Task CreateComment(string userId, int receiptId, string text)
        {
            var coment = new Comments()
            {
                UserId = userId,
                ReceiptId = receiptId,
                Text = text
            };
            await _context.Comments.AddAsync(coment);
        }

    }
}
