using Entities.Tamin;
using Entities.Tikets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class User : IdentityUser<int>, IEntity
    {
        public User()
        {
            IsActive = true;
            Random generator = new Random();
            CodePhone = generator.Next(0, 10000).ToString("0000");
        }

        public string CodePhone { get; set; }
        public string FullName { get; set; }
        public string ProfilePIC { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        public DateTimeOffset? LastLoginDate { get; set; }
        public ICollection<UserPayement> UserPayements { get; set; }
        public ICollection<Tiket> Tikets { get; set; }
        public ICollection<Employees> Employees { get; set; }
        public ICollection<Manufacturys> Manufacturys { get; set; }
        public ICollection<PayementHistory> payementHistories { get; set; }
        public ICollection<Post> Posts { get; set; }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Address).HasMaxLength(700);
            builder.Property(p => p.FullName).HasMaxLength(200);
            builder.Property(p => p.UserName).IsRequired(false).HasMaxLength(200);
            //builder.Property(p => p.Address).HasMaxLength(700);
            //builder.Property(p => p.FullName).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Email).IsRequired(false).HasMaxLength(200);
            builder.Property(p => p.PhoneNumber).IsRequired();
        }
    }

    
}
