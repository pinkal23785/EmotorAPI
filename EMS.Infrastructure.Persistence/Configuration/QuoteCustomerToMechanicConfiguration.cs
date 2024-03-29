using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class QuoteCustomerToMechanicConfiguration : IEntityTypeConfiguration<QuoteCustomerToMechanic>
    {
        public void Configure(EntityTypeBuilder<QuoteCustomerToMechanic> builder)
        {
            builder.ToTable("qo_customer_mechanic_t");
            builder.HasKey(b => b.QuoteCustomerMechanicId).HasName("PK_qo_customer_mechanic_t");
            builder.Property(b => b.QuoteCustomerMechanicId).HasColumnName("qocm_id");

            builder.Property(b => b.QuotationId).HasColumnName("qocm_quoteId");
            builder.Property(b => b.MechanicId).HasColumnName("qocm_mechanicId");

            builder.Property(b => b.Status).HasColumnName("qocm_status");
            builder.Property(b => b.Created).HasColumnName("qocm_created");

            builder.Property(b => b.Modified).HasColumnName("qocm_modified");
        }
    }
}
