using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts.Contracts;
using Ramsay.Services.Ramsay.Services.Ramsay.User.Receipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ramsay.Services.Ramsay.Services.Ramsay.Receipts
{
  public class RamsayReceiptServices : IRamsayReceiptsServices
    {

        
        private  RamsayDbContext _context;
        private RamsayUserReceipts _data;

        public RamsayReceiptServices(RamsayDbContext context,
            RamsayUserReceipts data)
        {
            this._context = context;
            this._data = data;
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
