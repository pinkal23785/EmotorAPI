using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class PartnerServiceIssuesConfiguration : IEntityTypeConfiguration<PartnerServiceIssues>
    {
        public void Configure(EntityTypeBuilder<PartnerServiceIssues> builder)
        {
            builder.ToTable("partner_service_issues_t");
            builder.HasKey(b => b.PartnerServiceIssueId).HasName("PK_partner_service_issues_t");
            builder.Property(b => b.PartnerServiceIssueId).HasColumnName("psi_id");
            builder.Property(b => b.ServiceIssueId).HasColumnName("psi_csi_id");
            builder.Property(b => b.UserID).HasColumnName("aspid");
            builder.Property(b => b.LabourCost).HasColumnName("psi_labour_cost");
            builder.Property(b => b.TimeTaken).HasColumnName("psi_time_taken");
            builder.Property(b => b.Notes).HasColumnName("psi_notes");
            builder.Property(b => b.PartnerIssueCreated).HasColumnName("csv_created");
            builder.Property(b => b.PartnerIssueModified).HasColumnName("csv_modified");
        }
    }
}

