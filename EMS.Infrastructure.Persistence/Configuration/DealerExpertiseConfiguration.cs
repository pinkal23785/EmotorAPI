using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class DealerExpertiseConfiguration : IEntityTypeConfiguration<DealerExpertise>
    {
        public void Configure(EntityTypeBuilder<DealerExpertise> builder)
        {
            builder.ToTable("dealer_vehicle_t");
            builder.HasKey(b => b.ID).HasName("PK_DealerExpertise");
            builder.Property(e => e.ID).HasColumnName("dv_id");
            builder.Property(b => b.UserId).HasColumnName("aspid");
            builder.Property(b => b.VehicleBrandId).HasColumnName("dv_cvb_id");
            builder.Property(b => b.DateCreated).HasColumnName("dv_created");
            builder.Property(b => b.DateModified).HasColumnName("dv_modified");
        }
    }
}
