using AutoMapper;
using Entities.Tamin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaminApp.Models;
using WebFramework.Api;

namespace TaminService.Models
{
    public class UserPayementDto:BaseDto<UserPayementDto,UserPayement>
    {
        public int UserID { get; set; }
        public decimal Bedehkari { get; set; }
        public decimal Bestankar { get; set; }
        public string Discription { get; set; }
        public DateTime dateTime { get; set; }
        public UserDto UserDto { get; set; }
        public override void CustomMappings(IMappingExpression<UserPayement, UserPayementDto> mappingExpression)
        {
            mappingExpression.ForMember(
                    dest => dest.UserDto,
                    config => config.MapFrom(src => src.User));

        }
    }
}
