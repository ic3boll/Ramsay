using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ramsay.Models;
using Ramsay.Data;

namespace Ramsay.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
       private RamsayDbContext context;


        public AccountController(RamsayDbContext dbContext)
        {
            this.context = dbContext;
        }


    }
}
