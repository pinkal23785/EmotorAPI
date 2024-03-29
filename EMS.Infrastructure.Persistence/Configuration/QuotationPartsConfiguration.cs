using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class QuotationPartsConfiguration : IEntityTypeConfiguration<QuotationParts>
    {
        public void Configure(EntityTypeBuilder<QuotationParts> builder)
        {

            builder.ToTable("qo_parts_updates_t");
            builder.HasKey(b => b.QuatationPartId).HasName("PK_qo_service_issues");

            builder.Property(b => b.QuatationPartId).HasColumnName("qd_id");
            builder.Property(b => b.QuotationId).HasColumnName("qo_id");
            builder.Property(b => b.PartType).HasColumnName("qd_part_type");

            builder.Property(b => b.MechanicId).HasColumnName("mechanic_id");
            builder.Property(b => b.PartName).HasColumnName("qd_part_name");

            builder.Property(b => b.Qty).HasColumnName("qd_qty");
            builder.Property(b => b.Cost).HasColumnName("qd_part_price");

            builder.Property(b => b.Notes).HasColumnName("qd_notes");

            builder.Property(b => b.Created).HasColumnName("qd_created");
            builder.Property(b => b.Modified).HasColumnName("qd_modified");
        }
    }
}
