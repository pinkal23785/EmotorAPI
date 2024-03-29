using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
   public class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.ToTable("mechanic_traning_t");
            builder.HasKey(b => b.TrainingID).HasName("PK_M_Training");
            builder.Property(e => e.TrainingID).HasColumnName("mt_id");
            builder.Property(b => b.UserId).HasColumnName("aspid");
            builder.Property(b => b.Name).HasColumnName("mt_name");
            builder.Property(b => b.VehicleCategory).HasColumnName("mt_vehicle_category");
            builder.Property(b => b.Year).HasColumnName("mt_year");
            builder.Property(b => b.Place).HasColumnName("mt_place");
            builder.Property(b => b.Duration).HasColumnName("mt_duration");
            builder.Property(b => b.Institute).HasColumnName("mt_institute");
            builder.Property(b => b.DateCreated).HasColumnName("mt_created");
            builder.Property(b => b.DateModified).HasColumnName("mt_modified");
        }
    }
}
