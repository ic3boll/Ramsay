using Ramsay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ramsay.Services.Ramsay.Services.Ramsay.Receipts.Contracts
{
    interface IRamsayReceiptsServices
    {
        IQueryable<Receipt> All();

        IQueryable<Receipt> allReceipts();

        IQueryable<Receipt> allReceiptsByUser();
    }
}
