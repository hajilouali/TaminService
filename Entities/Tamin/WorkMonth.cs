using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Tamin
{
    public class WorkMonth:BaseEntity
    {
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
        [ForeignKey("EmployeID")]
        public Employees Employees { get; set; }
        public KarMonth KarMonth { get; set; }
        public class UserConfiguration : IEntityTypeConfiguration<WorkMonth>
        {
            public void Configure(EntityTypeBuilder<WorkMonth> builder)
            {
                builder.HasOne(p => p.Employees).WithMany(p => p.WorkMonths).HasForeignKey(p => p.EmployeID);
                builder.HasOne(p => p.KarMonth).WithMany(p => p.WorkMonths).HasForeignKey(p => p.KarMonthID);
                builder.Property(p => p.DSW_ID).IsRequired().HasMaxLength(10);
                builder.Property(p => p.DSW_LISTNO).IsRequired().HasMaxLength(12);
                builder.Property(p => p.DSW_SDATE).IsRequired().HasMaxLength(8);
                builder.Property(p => p.DSW_EDATE).IsRequired().HasMaxLength(8);
            }
        }
    }
}
