
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class DealerAttributesConfiguration : IEntityTypeConfiguration<DealerAttributes>
    {
        public void Configure(EntityTypeBuilder<DealerAttributes> builder)
        {
            builder.ToTable("dealer_attributes_t");
            builder.HasKey(b => b.ID).HasName("PK_DealerAttributes");
            builder.Property(e => e.ID).HasColumnName("da_id");
            builder.Property(b => b.UserId).HasColumnName("aspid");
            builder.Property(b => b.GarageName).HasColumnName("da_shop_name");

            builder.Property(b => b.StartHours).HasColumnName("da_start_hours");
            builder.Property(b => b.EndHours).HasColumnName("da_end_hours");
            builder.Property(b => b.Experience).HasColumnName("da_experience");
            builder.Property(b => b.IsOnsiteSupport).HasColumnName("da_field_support");
            builder.Property(b => b.Is24Support).HasColumnName("da_24_7_support");
            builder.Property(b => b.Longitute).HasColumnName("da_longitute");
            builder.Property(b => b.Latitute).HasColumnName("da_latitute");
            builder.Property(b => b.DistanceCovered).HasColumnName("da_radius"); 
            builder.Property(b => b.IsOwnGarage).HasColumnName("da_service_center");
            builder.Property(b => b.TotalHelpers).HasColumnName("da_total_helpers");
            builder.Property(b => b.TotalMechanics).HasColumnName("da_total_mechanics");
            builder.Property(b => b.CurrentStatus).HasColumnName("da_current_status"); ;
            builder.Property(b => b.DateCreated).HasColumnName("da_created");
            builder.Property(b => b.ModifiedDate).HasColumnName("da_modified");
        }
    }
}
