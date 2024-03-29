using System;
using System.Collections.Generic;
using System.Text;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Persistence.Configuration
{
    class QuotationIssueConfiguration : IEntityTypeConfiguration<QuotationIssues>
    {
        public void Configure(EntityTypeBuilder<QuotationIssues> builder)
        {
            builder.ToTable("qo_service_issues_t");
            builder.HasKey(b => b.QuoteIssueId).HasName("PK_qo_service_issues");
            builder.Property(b => b.QuoteIssueId).HasColumnName("qsi_id");
            builder.Property(b => b.QuotationId).HasColumnName("qo_id");
            builder.Property(b => b.IssueId).HasColumnName("csi_id");
            builder.Property(b => b.IssueNotes).HasColumnName("qsi_notes");
            builder.Property(b => b.Created).HasColumnName("qsi_created");
            builder.Property(b => b.Modified).HasColumnName("qsi_modified");
        }
    }
}
