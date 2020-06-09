using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TaminWeb.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly SiteSettings _siteSetting;

        public ContactUsController(IConfiguration configuration)
        {
            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        public IActionResult Index()
        {
            ViewData["Info"] = _siteSetting;
            return View();
        }
    }
}