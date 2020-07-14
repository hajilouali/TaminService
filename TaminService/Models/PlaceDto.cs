using Entities.Tamin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace TaminService.Models
{
    public class PlaceDto:BaseDto<PlaceDto,Place>
    {
        public string Code { get; set; }
        public string DSW_IDPLC { get; set; }
    }
}
