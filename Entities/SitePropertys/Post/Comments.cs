using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.SitePropertys.Post
{
    public enum PostType
    {
        [Display(Name = "منتشر شده")]
        Published,
        [Display(Name = "منتشر نشده")]
        NotPublished
    }
    public class Comments : BaseEntity
    {
        public Comments()
        {
            IsShow = PostType.NotPublished;
            DateTime = DateTime.Now;
            ParentID = 0;
        }
        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید")]
        [MaxLength(500, ErrorMessage = "حداکثر {0} کاراکتر مورد قبول می باشد")]
        [Display(Name = "نظر")]
        public string Comment { get; set; }
        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید")]
        [MaxLength(150, ErrorMessage = "حداکثر {0} کاراکتر مورد قبول می باشد")]
        [Display(Name = "نام نظر دهنده")]
        public string User { get; set; }
        [Display(Name = "تاریخ انتشار")]
        public DateTime DateTime { get; set; }
        [Display(Name = "پاسخ به")]
        public int ParentID { get; set; }
        [Display(Name = "مربوط به مقاله")]
        public int PostID { get; set; }
        [Display(Name = "وضعیت")]
        public PostType IsShow { get; set; }

        public Entities.Post Post { get; set; }
    }
    public class PostConfiguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasOne(p => p.Post).WithMany(c => c.Comments).HasForeignKey(p => p.PostID);
        }
    }
}
