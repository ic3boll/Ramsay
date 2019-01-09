using Microsoft.AspNetCore.Http;
using Ramsay.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ramsay.ViewModels.Comment
{
    public class CommentCreateViewModel
    {
        public string Text { get; set; }

        public int ReceiptId { get; set; }

        public string UserId { get; set; }

        public string userName { get; set; }
    }
}
