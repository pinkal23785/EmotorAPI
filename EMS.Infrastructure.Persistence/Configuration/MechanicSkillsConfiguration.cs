using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
   public class MechanicSkillsConfiguration : IEntityTypeConfiguration<MechanicSkills>
    {
        public void Configure(EntityTypeBuilder<MechanicSkills> builder)
        {
            builder.ToTable("mechanic_skills_t");
            builder.HasKey(b => b.ID).HasName("PK_MechanicSkills");
            builder.Property(e => e.ID).HasColumnName("ms_id");
            builder.Property(b => b.UserId).HasColumnName("aspid");
            builder.Property(b => b.SkillID).HasColumnName("ms_cs_id");
            builder.Property(b => b.DateCreated).HasColumnName("ms_created");
            builder.Property(b => b.DateModified).HasColumnName("ms_modified");

        }
    }
}
