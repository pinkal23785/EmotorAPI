using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
   public class DealerPartsCatlogConfiguration : IEntityTypeConfiguration<DealerPartsCatlog>
    {
        public void Configure(EntityTypeBuilder<DealerPartsCatlog> builder)
        {
            builder.ToTable("dealer_part_catalog_t");
            builder.HasKey(b => b.ID).HasName("PK_DealerPartsCatlog");
            builder.Property(b => b.ID).HasColumnName("dpc_id");
            builder.Property(b => b.UserId).HasColumnName("aspid");
            builder.Property(b => b.SkillID).HasColumnName("dpc_cs_id");
            builder.Property(b => b.DateCreated).HasColumnName("dpc_created");
            builder.Property(b => b.DateModified).HasColumnName("dpc_modified");
        }
    }
}
