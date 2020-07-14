using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Text;

namespace Entities.Tamin
{
    public class Employees:BaseEntity
    {
        public Employees()
        {
            ListEmployeeID = 0;
            IsKarfarma = false;
        }

        public int UserID { get; set; }
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
        /// کد شغل
        /// </summary>
        public int jobid { get; set; }
        /// <summary>
        /// کد ملی
        /// </summary>
        public string PER_NATCOD { get; set; }
        public bool IsKarfarma { get; set; }
        public int ListEmployeeID { get; set; }
        [ForeignKey("jobid")]
        public Jobs Jobs { get; set; }

        public User User { get; set; }
        public ICollection<WorkMonth> WorkMonths { get; set; }
        public class UserConfiguration : IEntityTypeConfiguration<Employees>
        {
            public void Configure(EntityTypeBuilder<Employees> builder)
            {
                builder.HasOne(p => p.User).WithMany(p => p.Employees).HasForeignKey(p => p.UserID);
                builder.HasOne(p => p.Jobs).WithMany(p => p.Employees).HasForeignKey(p => p.jobid);

                builder.Property(p => p.DSW_ID1).IsRequired().HasMaxLength(10);
                builder.Property(p => p.DSW_FNAME).IsRequired().HasMaxLength(100);
                builder.Property(p => p.DSW_LNAME).IsRequired().HasMaxLength(100);
                builder.Property(p => p.DSW_DNAME).IsRequired().HasMaxLength(100);
                builder.Property(p => p.DSW_IDNO).IsRequired().HasMaxLength(15);
                builder.Property(p => p.DSW_IDATE).IsRequired().HasMaxLength(8);
                builder.Property(p => p.DSW_BDATE).IsRequired().HasMaxLength(8);
                builder.Property(p => p.DSW_SEX).IsRequired().HasMaxLength(3);
                builder.Property(p => p.PER_NATCOD).IsRequired().HasMaxLength(10);
            }
        }
    }
}
