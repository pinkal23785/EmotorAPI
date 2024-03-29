using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class VehicleBrandsConfiguration : IEntityTypeConfiguration<VehicleBrands>
    {
        public void Configure(EntityTypeBuilder<VehicleBrands> builder)
        {
            builder.ToTable("config_vehicle_brands_t");
            builder.HasKey(b => b.VehicleBrandId).HasName("PK_VehicleBrands");
            builder.Property(e => e.VehicleBrandId).HasColumnName("cvb_id");
            builder.Property(b => b.VehicleTypeId).HasColumnName("cvt_type_id"); 

            builder.Property(b => b.Name).HasColumnName("cvb_brand");
            builder.Property(b => b.Picture).HasColumnName("cvb_picture");
            
            builder.Property(b => b.DateCreated).HasColumnName("cvb_created");
            builder.Property(b => b.DateModified).HasColumnName("cvb_modified");
            builder.Property(b => b.Rank).HasColumnName("cvb_rank"); 
        }
    }
}
