using Causely.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Causely.Infrastructure.Data.Configurations;

public class ErrorClusterConfiguration : IEntityTypeConfiguration<ErrorCluster>
{
    public void Configure(EntityTypeBuilder<ErrorCluster> builder)
    {
        builder.Property(e => e.Id)
            .HasConversion(
                v => v.ToString(),
                v => Ulid.Parse(v))
            .HasMaxLength(26)
            .IsRequired();

        builder.Property(e => e.PrimaryFingerprint)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(e => e.RepresentativeMessage)
            .IsRequired();

        builder.Property(e => e.ExceptionType)
            .HasMaxLength(500);

        builder.Property(e => e.Service)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasMaxLength(50)
            .IsRequired();
    }
}
