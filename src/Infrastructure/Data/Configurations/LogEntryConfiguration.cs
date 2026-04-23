using Causely.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Causely.Infrastructure.Data.Configurations;

public class LogEntryConfiguration : IEntityTypeConfiguration<LogEntry>
{
    public void Configure(EntityTypeBuilder<LogEntry> builder)
    {
        builder.Property(e => e.Id)
            .HasConversion(
                v => v.ToString(),
                v => Ulid.Parse(v))
            .HasMaxLength(26)
            .IsRequired();

        builder.Property(e => e.Timestamp)
            .IsRequired();

        builder.Property(e => e.Service)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Environment)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Level)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Message)
            .IsRequired();

        builder.Property(e => e.ExceptionType)
            .HasMaxLength(500);

        builder.Property(e => e.Endpoint)
            .HasMaxLength(500);

        builder.Property(e => e.TraceId)
            .HasMaxLength(200);

        builder.Property(e => e.CreatedAt)
            .IsRequired();
    }
}
