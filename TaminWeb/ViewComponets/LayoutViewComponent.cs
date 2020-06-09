using Common;
using Data.Repositories;
using Entities.SitePropertys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebTamin.ViewComponets
{
    public enum NaveType
    {
        defult,
        type4
    }
    public class HeaderComponent: ViewComponent
    {
        private readonly SiteSettings _siteSetting;
        private readonly IRepository<SMenuItems> SMenuItems;
        public HeaderComponent(IConfiguration configuration, IRepository<SMenuItems> sMenuItems)
        {
            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
            SMenuItems = sMenuItems;
        }

        public async Task<IViewComponentResult> InvokeAsync( int type=0)
        {
            ViewData["PortalUrl"] = _siteSetting.SiteInfo.PortalURL;
            this.ViewData["navtype"] = type;
            ViewData["Logo"] = _siteSetting.SiteInfo.Logo;
            ViewData["Logo2"] = _siteSetting.SiteInfo.Logo2;
            var model = SMenuItems.TableNoTracking.ToList();
            return await Task.FromResult((IViewComponentResult)View(model));
        }
    }
    public class FooterComponent : ViewComponent
    {
        private readonly SiteSettings _siteSetting;

        public FooterComponent(IConfiguration configuration)
        {
            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_footer", _siteSetting));
        }
    }
    public class MenuComponent : ViewComponent
    {
        private readonly SiteSettings _siteSetting;

        public MenuComponent(IConfiguration configuration)
        {
            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View());
        }
    }
}
