using Entities.SitePropertys.Post;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Entities
{
    public class Post : BaseEntity
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید")]
        [MaxLength(70, ErrorMessage = "حداکثر {0} کاراکتر مورد قبول می باشد")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید")]
        [MaxLength(127, ErrorMessage = "حداکثر {0} کاراکتر مورد قبول می باشد")]
        public string Description { get; set; }
        [Display(Name = "دسته بندی")]
        public int CategoryId { get; set; }
        [Display(Name = "کاربر")]
        public int AuthorId { get; set; }
        [Display(Name = "محتوا")]
        [AllowHtml]
        public string Content { get; set; }
        [MaxLength(200, ErrorMessage = "حداکثر {0} کاراکتر مورد قبول می باشد")]
        public string Keys { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public Category Category { get; set; }
        public User Author { get; set; }

    }

    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {

            builder.HasOne(p => p.Category).WithMany(c => c.Posts).HasForeignKey(p => p.CategoryId);
            builder.HasOne(p => p.Author).WithMany(c => c.Posts).HasForeignKey(p => p.AuthorId);
        }
    }
}
