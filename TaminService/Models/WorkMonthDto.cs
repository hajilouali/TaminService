using AutoMapper;
using Entities.Tamin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace TaminService.Models
{
    public class WorkMonthDto:BaseDto<WorkMonthDto,WorkMonth>
    {
        public KarMonthDto KarMonthDto { get; set; }
        public EmployeeDto EmployeeDto { get; set; }
        public int KarMonthID { get; set; }
        public int EmployeID { get; set; }
        /// <summary>
        /// کد کارگاه
        /// </summary>
        public string DSW_ID { get; set; }
        /// <summary>
        /// سال عملکرد
        /// </summary>
        public int DSW_YY { get; set; }
        /// <summary>
        /// ماه عملکرد
        /// </summary>
        public int DSW_MM { get; set; }
        /// <summary>
        /// شماره لیست
        /// </summary>
        public string DSW_LISTNO { get; set; }
        /// <summary>
        /// تاریخ شروع به کار
        /// </summary>
        public string DSW_SDATE { get; set; }
        /// <summary>
        /// تاریخ ترک کار
        /// </summary>
        public string DSW_EDATE { get; set; }
        /// <summary>
        /// تعداد روز های کارکرد
        /// </summary>
        public int DSW_DD { get; set; }
        /// <summary>
        /// دستمزد روزانه
        /// </summary>
        public int DSW_ROOZ { get; set; }
        /// <summary>
        /// دستمزد ماهانه
        /// </summary>
        public int DSW_MAH { get; set; }
        /// <summary>
        /// مزایای ماهانه
        /// </summary>
        public int DSW_MAZ { get; set; }
        /// <summary>
        /// جمع دستمزد و مزایای ماهانه مشمول
        /// </summary>
        public int DSW_MASH { get; set; }
        /// <summary>
        /// جمع کل دستمزد و مزایای ماهانه
        /// </summary>
        public int DSW_TOTL { get; set; }
        /// <summary>
        /// حق بیمه سهم بیمه شده
        /// </summary>
        public int DSW_BIME { get; set; }
        /// <summary>
        /// نرخ پورسانتاژ
        /// </summary>
        public int DSW_PRATE { get; set; }
        public override void CustomMappings(IMappingExpression<WorkMonth, WorkMonthDto> mappingExpression)
        {
            mappingExpression.ForMember(
                    dest => dest.KarMonthDto,
                    config => config.MapFrom(src => src.KarMonth));
            mappingExpression.ForMember(
                    dest => dest.EmployeeDto,
                    config => config.MapFrom(src => src.Employees));
        }
    }
}
