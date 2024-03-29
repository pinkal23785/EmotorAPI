using System;
using System.Collections.Generic;
using System.Text;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Persistence.Configuration
{
    class QuotationMechanicConfiguration : IEntityTypeConfiguration<QuotationMechanicUpdates>
    {
        public void Configure(EntityTypeBuilder<QuotationMechanicUpdates> builder)
        {
            builder.ToTable("qo_mechanic_updates_t");
            builder.HasKey(b => b.QuotationIssueId).HasName("PK_qo_mechanic_updates");
            builder.Property(b => b.QuotationIssueId).HasColumnName("qm_id");

            builder.Property(b => b.QuotationCMId).HasColumnName("qocm_id");
            builder.Property(b => b.IssueId).HasColumnName("csi_id");
            

            builder.Property(b => b.MechanicId).HasColumnName("mechanic_id");
            builder.Property(b => b.LabourCost).HasColumnName("qm_labour_cost");
            builder.Property(b => b.TimeTaken).HasColumnName("qm_time_taken");

            builder.Property(b => b.Notes).HasColumnName("qm_notes");
            builder.Property(b => b.Created).HasColumnName("qm_created");
            builder.Property(b => b.Modified).HasColumnName("qm_modified");

            builder.Property(b => b.SkillId).HasColumnName("cs_id");
        }
    }
}
