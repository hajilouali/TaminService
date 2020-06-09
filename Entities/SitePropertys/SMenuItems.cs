using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.SitePropertys
{
    public class SMenuItems : BaseEntity
    {
        public string Title { get; set; }
        public int ParentID { get; set; }
        public string URL { get; set; }
        

    }
    public class ExpertConfiguration : IEntityTypeConfiguration<SMenuItems>
    {
        public void Configure(EntityTypeBuilder<SMenuItems> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
            builder.Property(p => p.URL).IsRequired().HasMaxLength(1500);
            //builder.HasOne(p => p.Author).WithMany(c => c.Posts).HasForeignKey(p => p.AuthorId);
        }
    }
}
