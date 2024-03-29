using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class MechanicExpertiseConfiguration : IEntityTypeConfiguration<MechanicExpertise>
    {
        public void Configure(EntityTypeBuilder<MechanicExpertise> builder)
        {
            builder.ToTable("mechanic_vehicle_t");
            builder.HasKey(b => b.ID).HasName("PK_MechanicSpeciality");
            builder.Property(e => e.ID).HasColumnName("mv_id");
            builder.Property(b => b.UserId).HasColumnName("aspid");
            builder.Property(b => b.VehicleBrandId).HasColumnName("mv_cvb_id");
            builder.Property(b => b.DateCreated).HasColumnName("mv_created");
            builder.Property(b => b.DateModified).HasColumnName("mv_modified");
        }
    }
}
