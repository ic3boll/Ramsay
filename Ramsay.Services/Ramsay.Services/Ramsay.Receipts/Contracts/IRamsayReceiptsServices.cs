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
         Task<IQueryable<Receipt>> All();
        Task<IQueryable<Receipt>> allReceipts();
    }
}
