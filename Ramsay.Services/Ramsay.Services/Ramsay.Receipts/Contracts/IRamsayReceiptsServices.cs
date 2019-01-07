using Ramsay.Models;
using Ramsay.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramsay.Services.Ramsay.Services.Ramsay.Receipts.Contracts
{
    interface IRamsayReceiptsServices
    {
         IQueryable<Receipt> All();

     

         IQueryable<Receipt> allReceipts();

         IQueryable<Receipt> allReceiptsById();

        IQueryable<Receipt> GetReceiptId(int id);


    }
}
