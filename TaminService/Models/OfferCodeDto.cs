using AutoMapper;
using Entities.Tamin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace TaminService.Models
{
    public class OfferCodeDto:BaseDto<OfferCodeDto,OffersCode>
    {
        public bool Isactive { get; set; }
        public string Code { get; set; }
        public DateTime? DateExpire { get; set; }
        public int? CountExpire { get; set; }
        public string Discription { get; set; }
        public int OfferRate { get; set; }
        public override void CustomMappings(IMappingExpression<OffersCode, OfferCodeDto> mappingExpression)
        {
            mappingExpression.ForMember(
                    dest => dest.Isactive,
                    config => config.MapFrom(src => src.DateExpire <= DateTime.Now || src.CountExpire > 0 ? true : false));

        }
    }
}
