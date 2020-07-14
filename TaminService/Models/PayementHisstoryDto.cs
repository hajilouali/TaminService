using Entities.Tamin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace TaminService.Models
{
    public class PayementHisstoryDto:BaseDto<PayementHisstoryDto, PayementHistory>
    {
        public bool IsSucess { get; set; }
        public long? Trackingnumber { get; set; }
        public string Transactioncode { get; set; }
        public int UserID { get; set; }
        public string Gateway { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
        public string Discription { get; set; }
        public string OfferCode { get; set; }
    }
}
