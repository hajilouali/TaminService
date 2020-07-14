using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Tamin
{
    public class OffersCode : BaseEntity
    {
        public OffersCode()
        {
            DateCreate = DateTime.Now;
        }
        [MaxLength(10)]
        public string Code { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateExpire { get; set; }
        public int? CountExpire { get; set; }
        [MaxLength(150)]
        public string Discription { get; set; }
        public int OfferRate { get; set; }
    }
}
