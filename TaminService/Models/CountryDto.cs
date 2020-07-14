using Entities.Tamin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace TaminService.Models
{
    public class CountryDto:BaseDto<CountryDto,Country>
    {
        public string Code { get; set; }
        public string DSW_NAT { get; set; }
    }
}
