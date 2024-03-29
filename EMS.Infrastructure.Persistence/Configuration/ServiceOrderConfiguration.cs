using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class ServiceOrderConfiguration: IEntityTypeConfiguration<ServiceOrders>
    {
        public void Configure(EntityTypeBuilder<ServiceOrders> builder)
        {
            builder.ToTable("service_order_t");
            builder.HasKey(b => b.ServiceOrderId).HasName("PK_service_order_t");
            builder.Property(b => b.ServiceOrderId).HasColumnName("so_id");
            builder.Property(b => b.ServiceOrderType).HasColumnName("so_type");

            builder.Property(b => b.CustomerId).HasColumnName("c_aspid");
            builder.Property(b => b.MechanicId).HasColumnName("m_aspid");
            builder.Property(b => b.ServiceCenterId).HasColumnName("d_aspid");
            builder.Property(b => b.Manufacture).HasColumnName("so_manufature");
            builder.Property(b => b.StartTime).HasColumnName("so_work_start_time");
            builder.Property(b => b.EndTime).HasColumnName("so_work_end_time");

            builder.Property(b => b.Status).HasColumnName("so_current_status");
            builder.Property(b => b.IsPartNeeded).HasColumnName("so_part_needed");

            builder.Property(b => b.ScheduleTime).HasColumnName("so_schedule_time");
            builder.Property(b => b.Lat).HasColumnName("so_latitude");
            builder.Property(b => b.Long).HasColumnName("so_longitute");

            builder.Property(b => b.SLA).HasColumnName("sla");

            builder.Property(b => b.QuotationId).HasColumnName("q_id");
            builder.Property(b => b.IsPartDelivered).HasColumnName("so_parts_delivery");

            builder.Property(b => b.VehicleType).HasColumnName("so_vehicle_type");
            builder.Property(b => b.VehicleBrand).HasColumnName("so_vehicle_brand");
            builder.Property(b => b.VehicleModel).HasColumnName("so_vehicle_model");
            builder.Property(b => b.VehicleFuelType).HasColumnName("so_vehicle_fuel");
            


            builder.Property(b => b.Created).HasColumnName("so_created");
            builder.Property(b => b.Modified).HasColumnName("so_modified");
        }
    }
}
