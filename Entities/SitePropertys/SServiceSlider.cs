using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.SitePropertys
{
    public class SServiceSlider:BaseEntity
    {
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Image { get; set; }
    }
}
