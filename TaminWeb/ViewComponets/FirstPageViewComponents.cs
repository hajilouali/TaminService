using Common.Utilities;
using Data.Repositories;
using Entities.SitePropertys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaminWeb.ViewComponets
{
    public enum QuestionType
    {
        InSection,
        InPage
    }
    public class SliderComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View(Jsonfile.xmltoobject()));
        }
    }
    public class ServicesSliderComponent : ViewComponent
    {
        private readonly IRepository<SServiceSlider> SServiceSlider;

        public ServicesSliderComponent(IRepository<SServiceSlider> sServiceSlider)
        {
            SServiceSlider = sServiceSlider;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View(SServiceSlider.TableNoTracking.ToList()));
        }
    }
    public class MobileSectionComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = Jsonfile.xmltoobject();
            return await Task.FromResult((IViewComponentResult)View(model));
        }
    }
    public class interfaceSectionComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = Jsonfile.xmltoobject();
            return await Task.FromResult((IViewComponentResult)View(model));
        }
    }
    public class signupSectionComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View());
        }
    }
    public class DownloadSectionComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = Jsonfile.xmltoobject();
            return await Task.FromResult((IViewComponentResult)View(model));
        }
    }
    public class QuestionSectionComponent : ViewComponent
    {
        private readonly IRepository<SQuestion> SQuestion;

        public QuestionSectionComponent(IRepository<SQuestion> sQuestion)
        {
            SQuestion = sQuestion;
        }

        public async Task<IViewComponentResult> InvokeAsync(QuestionType type =QuestionType.InSection,int Cunt =0)
        {
            ViewData["Type"] = type;
            ViewData["Cunt"] = Cunt;
            var model = SQuestion.TableNoTracking.ToList();
            return await Task.FromResult((IViewComponentResult)View(model));
        }
    }

}
