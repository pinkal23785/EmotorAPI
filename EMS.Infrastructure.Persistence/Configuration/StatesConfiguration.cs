using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class StatesConfiguration : IEntityTypeConfiguration<States>
    {
        public void Configure(EntityTypeBuilder<States> builder)
        {
            builder.ToTable("config_states_t");
            builder.HasKey(b => b.Id).HasName("PK_config_states_t");
            builder.Property(b => b.Id).HasColumnName("cs_Id");
            builder.Property(b => b.StateName).HasColumnName("cs_state_name");
            builder.Property(b => b.IsActive).HasColumnName("cs_is_active");
            builder.Property(b => b.DateCreated).HasColumnName("cs_created");
            builder.Property(b => b.DateModified).HasColumnName("cs_modified");
            builder.Property(b => b.Sequence).HasColumnName("cs_rank");
            
        }
    }
}
