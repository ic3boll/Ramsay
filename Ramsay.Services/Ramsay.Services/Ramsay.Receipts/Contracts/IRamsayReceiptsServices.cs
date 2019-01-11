using Ramsay.Models;
using System.Linq;
using System.Threading.Tasks;



namespace Ramsay.Services.Ramsay.Services.Ramsay.Receipts.Contracts
{
   public interface IRamsayReceiptsServices
    {
         Task<IQueryable<Receipt>> All();
        Task<IQueryable<Receipt>> allReceipts();
        int getCount();
        Task<IQueryable<Comments>> Allcomments();
        Task<IQueryable<Comments>> Comments();      
        Task<IQueryable<Comments>> AllcommentsId(int id);
     
        Task CreateComment(string userId, int receiptId, string text);
    }
}
