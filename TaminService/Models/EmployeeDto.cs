using AutoMapper;
using Entities.Tamin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebFramework.Api;

namespace TaminService.Models
{
    public class EmployeeDto : BaseDto<EmployeeDto, Employees>
    {
        public bool IsKarfarma { get; set; }

        /// <summary>
        /// شماره بیمه
        /// </summary>
        /// 

        public string DSW_ID1 { get; set; }
        /// <summary>
        /// نام
        /// </summary>
        public string DSW_FNAME { get; set; }
        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string DSW_LNAME { get; set; }
        /// <summary>
        /// نام پدر
        /// </summary>
        public string DSW_DNAME { get; set; }
        /// <summary>
        /// شماره شناسنامه
        /// </summary>
        public string DSW_IDNO { get; set; }
        /// <summary>
        /// محل صدور
        /// </summary>
        public string DSW_IDPLC { get; set; }
        /// <summary>
        /// تاریخ صدور
        /// </summary>
        public string DSW_IDATE { get; set; }
        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public string DSW_BDATE { get; set; }
        /// <summary>
        /// جنسیت
        /// </summary>
        public string DSW_SEX { get; set; }
        /// <summary>
        /// ملیت
        /// </summary>
        public string DSW_NAT { get; set; }
        
        /// <summary>
        /// کد ملی
        /// </summary>
        public string PER_NATCOD { get; set; }
        public int ListEmployeeID { get; set; }
        public int jobid { get; set; }

        public JobsDto Jobs { get; set; }

        public override void CustomMappings(IMappingExpression<Employees, EmployeeDto> mappingExpression)
        {
            //mappingExpression.ForMember(
            //        dest => dest.job,
            //        config => config.MapFrom(src => src.Jobs));
            
        }
    }
    
}
