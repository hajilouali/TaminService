using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Tamin
{
   public class UserPayement:BaseEntity
    {
        public UserPayement()
        {
            dateTime = DateTime.Now;
        }
        public int UserID { get; set; }
        public decimal Bedehkari { get; set; }
        public decimal Bestankar { get; set; }
        public string Discription { get; set; }
        public short Status { get; set; }
        public DateTime dateTime { get; set; }


        public User User { get; set; }
        public class UserConfiguration : IEntityTypeConfiguration<UserPayement>
        {
            public void Configure(EntityTypeBuilder<UserPayement> builder)
            {
                builder.HasOne(p => p.User).WithMany(p => p.UserPayements).HasForeignKey(p => p.UserID);
                builder.Property(p => p.Discription).HasMaxLength(500);

            }
        }
    }
}
