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


    }
}
