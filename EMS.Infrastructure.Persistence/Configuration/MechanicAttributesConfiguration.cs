
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class MechanicAttributesConfiguration : IEntityTypeConfiguration<MechanicAttributes>
    {
        public void Configure(EntityTypeBuilder<MechanicAttributes> builder)
        {
            builder.ToTable("mechanic_attributes_t");
            builder.HasKey(b => b.ID).HasName("PK_MechanicAttributes");
            builder.Property(e => e.ID).HasColumnName("ma_id");
            builder.Property(b => b.UserId).HasColumnName("aspid");
            builder.Property(b => b.StartHours).HasColumnName("ma_start_hours");
            builder.Property(b => b.EndHours).HasColumnName("ma_end_hours");
            builder.Property(b => b.Experience).HasColumnName("ma_experience");
            builder.Property(b => b.IsOnsiteSupport).HasColumnName("ma_field_support");
            builder.Property(b => b.Is24Support).HasColumnName("ma_24_7_support"); ;
            builder.Property(b => b.Longitute).HasColumnName("ma_longitute");
            builder.Property(b => b.Latitute).HasColumnName("ma_latitute");
            builder.Property(b => b.DistanceCovered).HasColumnName("ma_radius"); ;
            builder.Property(b => b.IsOwnGarage).HasColumnName("ma_permanent_garage"); ;
            builder.Property(b => b.GarageName).HasColumnName("ma_garage_name");
            builder.Property(b => b.TotalHelpers).HasColumnName("ma_total_helpers");
            builder.Property(b => b.TotalMechanics).HasColumnName("ma_total_mechanics");
            builder.Property(b => b.CurrentStatus).HasColumnName("ma_current_status");
            builder.Property(b => b.DateCreated).HasColumnName("ma_created");
            builder.Property(b => b.ModifiedDate).HasColumnName("ma_modified");

            builder.Property(b => b.Location).HasColumnName("ma_geo_location");

        }
    }
}
