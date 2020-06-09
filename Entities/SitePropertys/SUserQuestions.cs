using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.SitePropertys
{
    public class SUserQuestions:BaseEntity
    {
        public SUserQuestions()
        {
            DateTime = DateTime.Now;
            IsReade = false;
        }
        [Required(ErrorMessage ="لطفاً نام خود را وارد نمایید")]
        [MaxLength(50,ErrorMessage ="حداکثر تعداد کاراکتر{0} میباشد.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "لطفا شماره تماس خود را وارد نمایید")]
        [MinLength(11, ErrorMessage = "لطفا شماره تماس خود را به شکل صحیح وارد نمایید")]
        [MaxLength(11, ErrorMessage = "لطفا شماره تماس خود را به شکل صحیح وارد نمایید")]
        [RegularExpression("^0[0-9]*$", ErrorMessage = "لطفا شماره تماس خود را به شکل صحیح وارد نمایید")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "لطفاً سوال خود را مطرح نمایید")]
        [MaxLength(1500, ErrorMessage = "حداکثر تعداد کاراکتر{0} میباشد.")]
        public string Question { get; set; }
        [Required(ErrorMessage = "لطفاً عنوان را وارد نمایید")]
        [MaxLength(200, ErrorMessage = "حداکثر تعداد کاراکتر{0} میباشد.")]
        public string Subject { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsReade { get; set; }
    }
}
