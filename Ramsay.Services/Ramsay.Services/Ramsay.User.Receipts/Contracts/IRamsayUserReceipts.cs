using Ramsay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramsay.Services.Ramsay.Services.Ramsay.User.Receipts.Contracts
{
   public interface IRamsayUserReceipts
    {
         IQueryable<RamsayUser> allUsers();

        IQueryable<RamsayUser> UserById();

    }
}
