using Entities.Tamin;
using System;
using System.Collections.Generic;
using System.Text;
using WebFramework.Api;

namespace TaminService.Models
{
    public class EmployeeExcelmodel:BaseDto<EmployeeExcelmodel, Employees>
    {
        /// <summary>
        /// شماره بیمه
        /// </summary>
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
        /// کد شغل
        /// </summary>
        public string DSW_OCP { get; set; }
        /// <summary>
        /// کد ملی
        /// </summary>
        public string PER_NATCOD { get; set; }
    }
    public class EmployeeExcel
    {
        public List<EmployeeExcelmodel> list { get; set; }
    }
    public class EmployeeDBFmodel : BaseDto<EmployeeDBFmodel, Employees>
    {
        /// <summary>
        /// شماره بیمه
        /// </summary>
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
        /// کد شغل
        /// </summary>
        public string DSW_OCP { get; set; }
        /// <summary>
        /// کد ملی
        /// </summary>
        public string PER_NATCOD { get; set; }
    }
}
