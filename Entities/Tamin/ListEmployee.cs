using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Tamin
{
    public class ListEmployee:BaseEntity
    {
        public string Title { get; set; }
        public string Discription { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
    public class UserConfiguration : IEntityTypeConfiguration<ListEmployee>
    {
        public void Configure(EntityTypeBuilder<ListEmployee> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(150);
            builder.HasOne(p => p.User).WithMany(p => p.ListEmployees).HasForeignKey(p => p.UserID);

        }
    }
}
