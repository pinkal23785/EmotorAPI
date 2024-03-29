using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class ServiceOrderIssuesConfiguration : IEntityTypeConfiguration<ServiceOrderIssues>
    {
        public void Configure(EntityTypeBuilder<ServiceOrderIssues> builder)
        {
            builder.ToTable("service_order_issue_t");
            builder.HasKey(b => b.ServiceOrderIssueId).HasName("PK_service_order_issue_t");
            builder.Property(b => b.ServiceOrderIssueId).HasColumnName("soi_id");
            builder.Property(b => b.ServiceOrderId).HasColumnName("so_id");
            builder.Property(b => b.PartnerServiceIssueId).HasColumnName("soi_psi_id");
            builder.Property(b => b.LabourCost).HasColumnName("soi_labour_cost");
            builder.Property(b => b.Notes).HasColumnName("soi_notes");
            builder.Property(b => b.TimeTaken).HasColumnName("soi_time_taken");
            builder.Property(b => b.Created).HasColumnName("soi_created");
            builder.Property(b => b.Modified).HasColumnName("soi_modified");


            builder.HasOne(a => a.PartnerServiceIssues).WithMany(b => b.ServiceOrderIssues).HasForeignKey(c => c.PartnerServiceIssueId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_service_order_issue_t_partner_service_issues_t");
            builder.HasOne(a => a.ServiceOrders).WithMany(b => b.ServiceOrderIssues).HasForeignKey(c => c.ServiceOrderId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_service_order_issue_t_service_order_t");
        }
    }
}
