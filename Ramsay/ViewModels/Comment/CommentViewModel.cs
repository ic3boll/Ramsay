using Microsoft.AspNetCore.Http;
using Ramsay.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ramsay.ViewModels.Comment
{
    public class CommentViewModel
    {
        public string Text { get; set; }

        public string User { get; set; }


    }
}
