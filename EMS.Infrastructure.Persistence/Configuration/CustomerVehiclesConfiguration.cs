using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class CustomerVehiclesConfiguration:IEntityTypeConfiguration<CustomerVehicles>
    {
        public void Configure(EntityTypeBuilder<CustomerVehicles> builder)
        {
            builder.ToTable("customer_vehicle_details_t");
            builder.HasKey(b => b.CustomerVehicleId).HasName("PK_customer_vehicle_details_t");
            builder.Property(b => b.CustomerVehicleId).HasColumnName("cvd_id");
            builder.Property(b => b.UserId).HasColumnName("aspid");
            builder.Property(b => b.VehicleModelId).HasColumnName("cvd_model");
            builder.Property(b => b.Manufacture).HasColumnName("cvd_manufacture");
            builder.Property(b => b.FuelType).HasColumnName("cvd_fuel_type");
            builder.Property(b => b.ChasisNumber).HasColumnName("cvd_chasis_number");
            builder.Property(b => b.Lat).HasColumnName("cvd_lat");
            builder.Property(b => b.Long).HasColumnName("cvd_long");
            builder.Property(b => b.DateCreated).HasColumnName("cvd_created");
            builder.Property(b => b.DateModified).HasColumnName("cvd_modified");
        }
    }
}
