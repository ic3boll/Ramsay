using Ramsay.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ramsay.ViewModels.Receipt
{
    public class ReceiptViewModel
    {

        public string Name { get; set; }
        
        public ReceiptCategory Category { get; set; }
  
        public string Ingredients { get; set; }

        public string Preparation { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

    }
}
