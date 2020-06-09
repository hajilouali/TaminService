using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace TaminWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}