using Causely.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Causely.Infrastructure.Data.Configurations;

public class DeploymentConfiguration : IEntityTypeConfiguration<Deployment>
{
    public void Configure(EntityTypeBuilder<Deployment> builder)
    {
        builder.Property(e => e.Id)
            .HasConversion(
                v => v.ToString(),
                v => Ulid.Parse(v))
            .HasMaxLength(26)
            .IsRequired();

        builder.Property(e => e.Service)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Environment)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Version)
            .HasMaxLength(100);

        builder.Property(e => e.CommitSha)
            .HasMaxLength(100);
    }
}
