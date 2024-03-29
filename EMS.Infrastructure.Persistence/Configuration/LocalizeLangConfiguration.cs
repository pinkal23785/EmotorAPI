using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Persistence.Configuration
{
   public class LocalizeLangConfiguration : IEntityTypeConfiguration<LocalizeLang>
    {
        public void Configure(EntityTypeBuilder<LocalizeLang> builder)
        {
            builder.ToTable("config_language_t");
            builder.HasKey(b => b.Id).HasName("PK_config_language_t");
            builder.Property(b => b.Id).HasColumnName("cl_id");
            builder.Property(b => b.LanguageName).HasColumnName("cl_language_name");
            builder.Property(b => b.LanguageCode).HasColumnName("cl_language_iso_code");
            
            builder.Property(b => b.DateCreated).HasColumnName("cl_created");
            builder.Property(b => b.DateModified).HasColumnName("cl_modified");
            builder.Property(b => b.Sequence).HasColumnName("cl_rank");
        }
    }
}
