using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Tamin
{
    public class PayementHistory:BaseEntity
    {
        public bool IsSucess { get; set; }
        public string CodeRahgiri { get; set; }
        public int UserID { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
        public string Discription { get; set; }
        public User User { get; set; }
        public class UserConfiguration : IEntityTypeConfiguration<PayementHistory>
        {
            public void Configure(EntityTypeBuilder<PayementHistory> builder)
            {
                builder.HasOne(p => p.User).WithMany(p => p.payementHistories).HasForeignKey(p => p.UserID);
                builder.Property(p => p.CodeRahgiri).HasMaxLength(500);
                builder.Property(p => p.Discription).IsRequired().HasMaxLength(500);              
            }
        }
    }
}
