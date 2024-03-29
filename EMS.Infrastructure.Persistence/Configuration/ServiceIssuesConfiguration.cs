using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
   public class ServiceIssuesConfiguration : IEntityTypeConfiguration<ServiceIssues>
    {
        public void Configure(EntityTypeBuilder<ServiceIssues> builder)
        {
            builder.ToTable("config_service_issues_t");
            builder.HasKey(b => b.ServiceIssueId).HasName("PK_config_service_issues_t");
            builder.Property(b => b.ServiceIssueId).HasColumnName("csi_id");
            builder.Property(b => b.RecordId).HasColumnName("csi_rec_id");
            builder.Property(b => b.IssueName).HasColumnName("csi_issue_name");


            builder.Property(b => b.SkillId).HasColumnName("csi_cs_id");
            builder.Property(b => b.ParentId).HasColumnName("csi_parentId");
            builder.Property(b => b.IsCar).HasColumnName("csi_car");
            builder.Property(b => b.IsBike).HasColumnName("csi_bike");
            builder.Property(b => b.IsTruck).HasColumnName("csi_truck");
            builder.Property(b => b.IsTractor).HasColumnName("csi_tractor");
            builder.Property(b => b.Is3Wheeler).HasColumnName("csi_3_wheeler");
            builder.Property(b => b.IsMiniTruck).HasColumnName("csi_mini_truck");
            builder.Property(b => b.IsConstruction).HasColumnName("csi_construction");
            builder.Property(b => b.IsBus).HasColumnName("csi_bus");


            builder.Property(b => b.IsPetrol).HasColumnName("csi_fuel_petrol");
            builder.Property(b => b.IsDiesel).HasColumnName("csi_fuel_diesel");
            builder.Property(b => b.IsCNG).HasColumnName("csi_fuel_cng");
            builder.Property(b => b.IsLPG).HasColumnName("csi_fuel_lpg");
            builder.Property(b => b.IsElectric).HasColumnName("csi_fuel_electric");
            builder.Property(b => b.IsHybrid).HasColumnName("csi_fuel_hybrid");
            builder.Property(b => b.IsActualService).HasColumnName("csi_is_actual_service");
            builder.Property(b => b.IsPopularService).HasColumnName("csi_is_popular");
            builder.Property(b => b.Icon).HasColumnName("csi_icon");
            
            builder.Property(b => b.ServiceIssueCreated).HasColumnName("csv_created");
            builder.Property(b => b.ServiceIssueModified).HasColumnName("csv_modified");
        }
    }
}
