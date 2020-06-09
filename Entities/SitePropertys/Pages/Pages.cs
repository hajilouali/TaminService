using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace Entities.SitePropertys.Pages
{
    public class Pages:BaseEntity
    {
        public Pages()
        {
            DateTime = DateTime.Now;
        }
        [MaxLength(70,ErrorMessage ="حداکثر کاراکتر مجاز {0} میباشد")]
        [Required(ErrorMessage ="لطفاً عنوان صفحه را وارد نمایید")]
        [Display(Name ="عنوان صفحه")]
        public string PageTitle { get; set; }
        [Required(ErrorMessage = "لطفاً توضیحات مختصر صفحه را وارد نمایید")]
        [MaxLength(150, ErrorMessage = "حداکثر کاراکتر مجاز {0} میباشد")]
        [Display(Name = "توضیحات مختصر")]
        public string ShortDiscription { get; set; }
        [AllowHtml]
        [Display(Name = "محتوا")]
        public string PageContent { get; set; }
        [Display(Name = "تاریخ")]
        public DateTime DateTime { get; set; }
        [Display(Name = "کلمات کلیدی")]
        public string Keys { get; set; }

    }
}
