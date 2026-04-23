using Causely.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Causely.Infrastructure.Data.Configurations;

public class InsightConfiguration : IEntityTypeConfiguration<Insight>
{
    public void Configure(EntityTypeBuilder<Insight> builder)
    {
        builder.Property(e => e.Id)
            .HasConversion(
                v => v.ToString(),
                v => Ulid.Parse(v))
            .HasMaxLength(26)
            .IsRequired();

        builder.Property(e => e.ErrorClusterId)
            .HasConversion(
                v => v.HasValue ? v.Value.ToString() : null,
                v => string.IsNullOrWhiteSpace(v) ? null : Ulid.Parse(v))
            .HasMaxLength(26);

        builder.Property(e => e.Summary)
            .IsRequired();

        builder.Property(e => e.RootCauseText)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasMaxLength(50)
            .IsRequired();
    }
}
