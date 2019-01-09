using System;
using System.Collections.Generic;
using System.Text;

namespace Ramsay.Models
{
   public class Comments
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string UserId { get; set; }

        public RamsayUser User { get; set; }

        public int ReceiptId { get; set; }

        public Receipt Receipt { get; set; }
    }
}
