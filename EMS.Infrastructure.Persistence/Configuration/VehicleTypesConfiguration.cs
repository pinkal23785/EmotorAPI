using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class VehicleTypesConfiguration : IEntityTypeConfiguration<VehicleTypes>
    {
        public void Configure(EntityTypeBuilder<VehicleTypes> builder)
        {
            builder.ToTable("config_vehicle_types_t");
            builder.HasKey(b=>b.VehicleTypeId).HasName("PK_VehicleTypes");
            builder.Property(b => b.VehicleTypeId).HasColumnName("cvt_id")
                .UseSqlServerIdentityColumn();

            builder.Property(b => b.Name).HasColumnName("cvt_type");
            builder.Property(b => b.DateCreated).HasColumnName("cvt_created");
            builder.Property(b => b.DateModified).HasColumnName("cvt_modified");
            builder.Property(b => b.CreatedBy).HasColumnName("cvt_createdby");
            builder.Property(b => b.Picture).HasColumnName("cvt_picture");
            builder.Property(b => b.Sequence).HasColumnName("cvt_rank");
            builder.Property(b => b.cvt_type_hi).HasColumnName("cvt_type_hi");
            builder.Property(b => b.IsActive).HasColumnName("cvt_is_active");
            



        }
    }
}
