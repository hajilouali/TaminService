using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Tamin
{
    public class KarMonth:BaseEntity
    {
        public KarMonth()
        {
            DateCreate = DateTime.Now;
        }
        public DateTime DateCreate { get; set; }
        public int ManufacturyID { get; set; }
        /// <summary>
        /// نوع لیست
        /// </summary>
        public int DSK_KIND { get; set; }
        /// <summary>
        /// سال عملکرد
        /// </summary>
        public int DSK_YY { get; set; }
        /// <summary>
        /// ماه عملکرد
        /// </summary>
        public int DSK_MM { get; set; }
        /// <summary>
        /// شماره لیست
        /// </summary>
        public string DSK_LISTNO { get; set; }
        /// <summary>
        /// توضیحات لیست
        /// </summary>
        public string DSK_DISC { get; set; }
        /// <summary>
        /// تعداد کارکنان
        /// </summary>
        public int DSK_NUM { get; set; }
        /// <summary>
        /// مجموع روز های کارکرد
        /// </summary>
        public int DSK_TDD { get; set; }
        /// <summary>
        /// مجموع دستمزد روزانه
        /// </summary>
        public int DSK_TROOZ { get; set; }
        /// <summary>
        /// مجموع دستمزد ماهانه
        /// </summary>
        public int DSK_TMAH { get; set; }
        /// <summary>
        /// مجموع مزایای ماهانه مشمول
        /// </summary>
        public int DSK_TMAZ { get; set; }
        /// <summary>
        /// مجموع دستمزد و مزایای ماهانه مشمول
        /// </summary>
        public int DSK_TMASH { get; set; }
        /// <summary>
        /// مجموع کل مزایای ماهانه( مشمول و غیر مشمول)
        /// </summary>
        public int DSK_TTOTL { get; set; }
        /// <summary>
        /// مجموع حق بیمه سهم بیمه شده
        /// </summary>
        public int DSK_TBIME { get; set; }
        /// <summary>
        /// مجموع حق بیمه سهم کارفرما
        /// </summary>
        public int DSK_TKOSO { get; set; }
        /// <summary>
        /// مجموع حق بیمه بیکاری
        /// </summary>
        public int DSK_BIC { get; set; }
        
        /// <summary>
        /// نرخ حق پورسانتاژ
        /// </summary>
        public int DSK_PRATE { get; set; }
        /// <summary>
        /// نرخ مشاغل سخت زیان آور
        /// </summary>
        public int DSK_BIMH { get; set; }
        public Manufacturys Manufacturys { get; set; }
        public IEnumerable<WorkMonth> WorkMonths { get; set; }
        public class UserConfiguration : IEntityTypeConfiguration<KarMonth>
        {
            public void Configure(EntityTypeBuilder<KarMonth> builder)
            {
                builder.HasOne(p => p.Manufacturys).WithMany(p => p.KarMonths).HasForeignKey(p => p.ManufacturyID);
                builder.Property(p => p.DSK_KIND).IsRequired().HasMaxLength(10);
                builder.Property(p => p.DSK_YY).IsRequired().HasMaxLength(100);
                builder.Property(p => p.DSK_MM).IsRequired().HasMaxLength(100);
                builder.Property(p => p.DSK_LISTNO).IsRequired().HasMaxLength(12);
                builder.Property(p => p.DSK_DISC).HasMaxLength(100);
                builder.Property(p => p.DSK_NUM).IsRequired().HasMaxLength(99999);
                builder.Property(p => p.DSK_TDD).IsRequired().HasMaxLength(999999);

            }
        }
    }
}
