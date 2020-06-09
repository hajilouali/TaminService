using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.SitePropertys
{
    public class SQuestion:BaseEntity
    {
        [MaxLength(500)]
        public string Question { get; set; }
        [MaxLength(1000)]
        public string Respons { get; set; }
    }
}
