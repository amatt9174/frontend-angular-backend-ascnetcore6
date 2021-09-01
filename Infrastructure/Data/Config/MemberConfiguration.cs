using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class AppMemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(k => k.MId);
            builder.Property(p => p.MId).HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.HasIndex(i => i.TKey).IsUnique(false);
            builder.Property(p => p.TKey).IsRequired(true);

            builder.Property(p => p.EMail).IsRequired(true).HasMaxLength(100);
            builder.Property(p => p.FirstName).IsRequired(true).HasMaxLength(40);
            builder.Property(p => p.MiddleInitial).IsRequired(false).HasMaxLength(1);
            builder.Property(P => P.LastName).IsRequired(true).HasMaxLength(40);
            builder.Property(P => P.Status).IsRequired(true).HasMaxLength(40);
            builder.Property(p => p.DateCreated ).IsRequired(true);   
            builder.Property(p => p.LocalTimezoneCreated)
                .IsRequired(true).HasDefaultValue("TimezoneInfo.Local.Id").HasMaxLength(50);  
            builder.Property(p => p.DateUpdated ).IsRequired(true);
            builder.Property(p => p.LocalTimezoneUpdated)
                .IsRequired(true).HasDefaultValue("TimezoneInfo.Local.Id").HasMaxLength(50);  
        }
    }
}