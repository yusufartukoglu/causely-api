namespace Causely.Domain.Entities;

public class ErrorCluster
{
    public Ulid Id { get; set; } = Ulid.NewUlid();

    public string PrimaryFingerprint { get; set; } = string.Empty;

    public string RepresentativeMessage { get; set; } = string.Empty;

    public string? ExceptionType { get; set; }

    public string Service { get; set; } = string.Empty;

    public DateTime FirstSeenAt { get; set; }

    public DateTime LastSeenAt { get; set; }

    public int Frequency { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
