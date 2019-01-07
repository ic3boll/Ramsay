using Microsoft.AspNetCore.Http;
using Ramsay.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ramsay.ViewModels
{
    public class ReceiptBindingModel
    {
        public string Name { get; set; }

        public ReceiptCategory Category { get; set; }

        public string Ingredients { get; set; }

        public string Preparation { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
