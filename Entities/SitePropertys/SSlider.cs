using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class SSlider:BaseEntity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Discription { get; set; }

    }
    public class ExpertConfiguration : IEntityTypeConfiguration<SSlider>
    {
        public void Configure(EntityTypeBuilder<SSlider> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(200);
            builder.Property(p => p.Discription).HasMaxLength(1000);
            builder.Property(p => p.Url).HasMaxLength(1500);
        }
    }
}
