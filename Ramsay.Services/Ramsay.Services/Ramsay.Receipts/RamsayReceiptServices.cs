using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts.Contracts;

using System;
using System.Linq;

namespace Ramsay.Services.Ramsay.Services.Ramsay.Receipts
{
    public class RamsayReceiptServices : IRamsayReceiptsServices
    {

        
        private  RamsayDbContext _context;
   

        public RamsayReceiptServices(RamsayDbContext context)
        {
            this._context = context;
        
        }

        public IQueryable<Receipt> All() => this._context.Receipts;
        public IQueryable<Receipt> allReceipts()
        {
            return this.All().OrderBy(n => n.Name);
        }

        public IQueryable<Receipt> allReceiptsByUser()
        {
            throw new NotImplementedException();
        }
        // return this.All().OrderBy(n=>n.Name).Where(n=>n.Id ==_data.UserById._data)

    }
}
