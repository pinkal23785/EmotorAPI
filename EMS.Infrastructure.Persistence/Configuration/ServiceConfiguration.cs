using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Services>
    {
        public void Configure(EntityTypeBuilder<Services> builder)
        {
            builder.ToTable("config_services_t");
            builder.HasKey(b => b.ServiceId).HasName("PK_config_services_t");
            builder.Property(b => b.ServiceId).HasColumnName("csv_id");
            builder.Property(b => b.ServiceName).HasColumnName("csv_name");
            builder.Property(b => b.SkillId).HasColumnName("csv_cs_id");
            builder.Property(b => b.ServiceCreated).HasColumnName("csv_created");
            builder.Property(b => b.ServiceModified).HasColumnName("csv_modified");
            //builder.Property(b => b.Sequence).HasColumnName("cs_rank");
            //builder.Property(b => b.cs_skill_hi).HasColumnName("cs_skill_hi");
        }
    }
}