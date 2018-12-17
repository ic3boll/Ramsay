using Microsoft.AspNetCore.Identity;
using Ramsay.Models;
using Ramsay.Models.Enums;
using System;

namespace Ramsay.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        public string Name { get; set; }
            
        public ReceiptCategory Category { get; set; }

        public string Ingredients { get; set; }

        public string Preparation { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string UserId { get; set; }

        public RamsayUser User { get; set; }


    }
}
