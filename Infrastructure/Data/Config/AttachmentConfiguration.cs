using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.HasKey(k => k.AtId);
            // builder.Property(p => p.AtId).HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(p => p.AtId).HasDefaultValueSql("uuid_generate_v4()");
            builder.HasIndex(i => i.TKey).IsUnique(false);
            builder.Property(p => p.TKey).IsRequired(true);

            builder.HasOne(m => m.Member).WithMany().HasForeignKey(m => m.MId);

            builder.Property(P => P.Status).IsRequired(true).HasMaxLength(40);
            builder.Property(p => p.AName).IsRequired(true).HasMaxLength(256);
            builder.Property(p => p.AGroup).IsRequired(true).HasMaxLength(256);
            builder.Property(p => p.ALoc).IsRequired(true).HasMaxLength(256);
            builder.Property(p => p.AType).IsRequired(true).HasMaxLength(40);
            builder.Property(p => p.AFormat).IsRequired(true).HasMaxLength(40);
            builder.Property(p => p.ADesc).IsRequired(true).HasMaxLength(512);
            builder.Property(p => p.ACypher).IsRequired(false).HasMaxLength(40);
            builder.Property(p => p.Remarks).IsRequired(false).HasMaxLength(256);
            builder.Property(p => p.Usage).IsRequired(false).HasMaxLength(40);
            builder.Property(p => p.DateCreated ).IsRequired(true);   
            builder.Property(p => p.LocalTimezoneCreated)
                .IsRequired(true).HasDefaultValue("TimezoneInfo.Local.Id").HasMaxLength(50);  
            builder.Property(p => p.DateUpdated ).IsRequired(true);
            builder.Property(p => p.LocalTimezoneUpdated)
                .IsRequired(true).HasDefaultValue("TimezoneInfo.Local.Id").HasMaxLength(50);  

        }
    }
}