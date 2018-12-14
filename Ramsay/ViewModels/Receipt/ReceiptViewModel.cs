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
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Category: ")]
        public ReceiptCategory Category { get; set; }
        [Required]
        [Display(Name = "Ingredients")]
        public string Ingredients { get; set; }
        [Required]
        [Display(Name = "Preparation")]
        public string Preparation { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public string Image { get; set; }

    }
}
