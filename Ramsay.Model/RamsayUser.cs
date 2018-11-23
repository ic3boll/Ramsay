using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Ramsay.Models
{
    public class RamsayUser : IdentityUser
    {

        public string Nickname { get; set; }

    }
}
