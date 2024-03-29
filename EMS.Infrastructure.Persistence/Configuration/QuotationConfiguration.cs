using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class QuotationConfiguration : IEntityTypeConfiguration<Quotations>
    {
        public void Configure(EntityTypeBuilder<Quotations> builder)
        {
            builder.ToTable("qo_customer_t");
            builder.HasKey(b => b.QuotationId).HasName("PK_qo_customer");
            builder.Property(b => b.QuotationId).HasColumnName("qo_id");
            builder.Property(b => b.CustomerId).HasColumnName("customer_id");
            builder.Property(b => b.QuoteExpireTime).HasColumnName("qo_expire_time");
            builder.Property(b => b.Notes).HasColumnName("qo_notes");
            builder.Property(b => b.VehicleModel).HasColumnName("qo_vehicle_model");
            builder.Property(b => b.Manufacture).HasColumnName("qo_manufacture");
            builder.Property(b => b.Lat).HasColumnName("qo_lat");
            builder.Property(b => b.Long).HasColumnName("qo_long");
            builder.Property(b => b.Created).HasColumnName("qo_created");
            builder.Property(b => b.Modified).HasColumnName("qo_modified");

        }
    }
}
