using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("user_info_t");
            builder.HasKey(b => b.ID).HasName("PK_Users_1");
            builder.Property(b => b.ID).HasColumnName("ui_id");
            builder.Property(b => b.UserId).HasColumnName("aspid");
            builder.Property(b => b.UserType).HasColumnName("ui_type");
            builder.Property(b => b.Name).HasColumnName("ui_name");
            builder.Property(b => b.Address).HasColumnName("ui_address");
            builder.Property(b => b.State).HasColumnName("ui_state");
            builder.Property(b => b.City).HasColumnName("ui_city");
            builder.Property(e => e.Pincode).HasColumnName("ui_pincode");
            builder.Property(b => b.DOB).HasColumnName("ui_dob");
            builder.Property(b => b.DateCreated).HasColumnName("ui_created");
            builder.Property(b => b.ModifiedDate).HasColumnName("ui_modified");
        }
    }
}
