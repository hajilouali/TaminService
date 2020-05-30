using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Tamin
{
    public class Manufacturys:BaseEntity
    {
        public int UserID { get; set; }
        /// <summary>
        /// کد کارگاه
        /// </summary>
        public string DSK_ID { get; set; }
        /// <summary>
        /// نام کارگاه
        /// </summary>
        public string DSK_NAME { get; set; }
        /// <summary>
        /// نام کارفرما 
        /// </summary>
        public string DSK_FARM { get; set; }
        /// <summary>
        /// آدرس کارگاه
        /// </summary>
        public string DSK_ADRS { get; set; }        
        /// <summary>
        /// ردیف پیمان
        /// </summary>
        public string MON_PYM { get; set; }
        /// <summary>
        /// نرخ حق بیمه
        /// </summary>
        public int DSK_RATE { get; set; }
        public ICollection<KarMonth> KarMonths { get; set; }
        public User User { get; set; }
        public class UserConfiguration : IEntityTypeConfiguration<Manufacturys>
        {
            public void Configure(EntityTypeBuilder<Manufacturys> builder)
            {
                builder.HasOne(p => p.User).WithMany(p => p.Manufacturys).HasForeignKey(p => p.UserID);
                builder.Property(p => p.DSK_ID).IsRequired().HasMaxLength(10);
                builder.Property(p => p.DSK_NAME).IsRequired().HasMaxLength(100);
                builder.Property(p => p.DSK_FARM).IsRequired().HasMaxLength(100);
                builder.Property(p => p.DSK_ADRS).IsRequired().HasMaxLength(100);
                builder.Property(p => p.MON_PYM).IsRequired().HasMaxLength(3);

            }
        }
    }
}
