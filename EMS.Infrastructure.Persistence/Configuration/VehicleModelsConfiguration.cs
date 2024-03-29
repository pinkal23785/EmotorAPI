using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class VehicleModelsConfiguration : IEntityTypeConfiguration<VehicleModels>
    {
        public void Configure(EntityTypeBuilder<VehicleModels> builder)
        {
            builder.ToTable("config_vehicle_models_t");
            builder.HasKey(b => b.ModelId).HasName("PK_config_vehicle_models_t");
            builder.Property(b => b.ModelId).HasColumnName("cvm_id");
            builder.Property(b => b.BrandId).HasColumnName("cvm_cvb_id");
            builder.Property(b => b.ModelName).HasColumnName("cvm_model_name");
            builder.Property(b => b.ModelStart).HasColumnName("cvm_model_start");
            builder.Property(b => b.ModelEnd).HasColumnName("cvm_model_end");

            builder.Property(b => b.IsPertol).HasColumnName("cvm_fuel_petrol");
            builder.Property(b => b.IsDiesel).HasColumnName("cvm_fuel_diesel");
            builder.Property(b => b.IsCNG).HasColumnName("cvm_fuel_cng");
            builder.Property(b => b.IsLPG).HasColumnName("cvm_fuel_lpg");

            builder.Property(b => b.IsElectric).HasColumnName("cvm_fuel_electric");
            builder.Property(b => b.IsHybrid).HasColumnName("cvm_fuel_hybrid");

            builder.Property(b => b.IsLuxery).HasColumnName("cvm_luxery");
            builder.Property(b => b.IsActive).HasColumnName("cvm_is_active");

            builder.Property(b => b.Created).HasColumnName("cvm_created");
            builder.Property(b => b.Modified).HasColumnName("cvm_modified");
            builder.Property(b => b.Rank).HasColumnName("cvm_rank");
            builder.Property(b => b.IsActive).HasColumnName("cvm_is_active");

            builder.Property(b => b.SImage).HasColumnName("cvm_image_50");
            builder.Property(b => b.BImage).HasColumnName("cvm_image_250");
        }
    }
}
