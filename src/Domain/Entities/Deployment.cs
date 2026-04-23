namespace Causely.Domain.Entities;

public class Deployment
{
    public Ulid Id { get; set; } = Ulid.NewUlid();

    public string Service { get; set; } = string.Empty;

    public string Environment { get; set; } = string.Empty;

    public string? Version { get; set; }

    public string? CommitSha { get; set; }

    public DateTime DeployedAt { get; set; }

    public DateTime CreatedAt { get; set; }
}
