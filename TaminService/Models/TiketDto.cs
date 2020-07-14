using AutoMapper;
using Entities.Tikets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace TaminApp.Models
{
    public class TiketDto:BaseDto<TiketDto,Tiket>
    {
        public int id { get; set; }
        public string Title { get; set; }
        public short Level { get; set; }
        public string LevelString { get; set; }
        public bool IsAdminSide { get; set; }
        public int UserID { get; set; }
        public string User { get; set; }
        public DateTime DataCreate { get; set; }
        public string DataCreateString { get; set; }
        public DateTime DataModified { get; set; }
        public string DataModifiedstring { get; set; }
        public List<TiketContentDto> tiketContents { get; set; }
        public override void CustomMappings(IMappingExpression<Tiket, TiketDto> mappingExpression)
        {
            mappingExpression.ForMember(
                    dest => dest.DataCreateString,
                    config => config.MapFrom(src => $"{src.DataCreate.ToPersianDateTime()}"));
            mappingExpression.ForMember(
                    dest => dest.DataModifiedstring,
                    config => config.MapFrom(src => $"{src.DataModified.ToPersianDateTime()}"));
            mappingExpression.ForMember(
                    dest => dest.User,
                    config => config.MapFrom(src => $"{src.User.FullName}"));
            mappingExpression.ForMember(
                    dest => dest.LevelString,
                    config => config.MapFrom(src => src.Level==1? "عادی" :
                    src.Level==2? "مهم" :
                    src.Level==3? "خیلی مهم" : ""));
           

        }
    }
    public class TiketContentDto : BaseDto<TiketContentDto, TiketContent>
    {
        public int id { get; set; }
        public int TiketId { get; set; }
        public bool IsAdminSide { get; set; }
        public string Text { get; set; }
        public string FileURL { get; set; }
        public int UserID { get; set; }
        public string User { get; set; }
        public DateTime DataCreate { get; set; }
        public DateTime DataModified { get; set; }
        public override void CustomMappings(IMappingExpression<TiketContent, TiketContentDto> mappingExpression)
        {
            mappingExpression.ForMember(
                    dest => dest.User,
                    config => config.MapFrom(src => $"{src.Tiket.User.FullName}"));
        }
    }
}
