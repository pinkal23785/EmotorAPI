using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
    public class SkillsConfiguration : IEntityTypeConfiguration<Skills>
    {
        public void Configure(EntityTypeBuilder<Skills> builder)
        {
            builder.ToTable("config_skills_t");
            builder.HasKey(b => b.ID).HasName("PK_Skills");
            builder.Property(b=>b.ID).HasColumnName("cs_id");
            builder.Property(b => b.Name).HasColumnName("cs_skill");
            builder.Property(b => b.IsMechanicSkill).HasColumnName("cs_skill_for");
            builder.Property(b => b.Picture).HasColumnName("cs_picture");
            builder.Property(b => b.DateCreated).HasColumnName("cs_created");
            builder.Property(b => b.ModifiedDate).HasColumnName("cs_modified");
            builder.Property(b => b.Sequence).HasColumnName("cs_rank");
            builder.Property(b => b.cs_skill_hi).HasColumnName("cs_skill_hi");
        }
    }
}

