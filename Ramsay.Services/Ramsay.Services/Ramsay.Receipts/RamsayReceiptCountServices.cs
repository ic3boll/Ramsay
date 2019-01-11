using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Models.Interfaces.Repositories;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts.Contracts;

namespace Ramsay.Services.Ramsay.Services.Ramsay.Receipts
{
  public class RamsayReceiptCountServices : IRamsayReceiptCountServices
    {


        

         private readonly IRepository<Receipt> _receiptRepository;

        public RamsayReceiptCountServices(
            IRepository<Receipt> receiptRepository)
        {
            
             this._receiptRepository = receiptRepository;
        }



        public int getCount()
        {
            return this._receiptRepository.All().Count();
        }
    }
}
