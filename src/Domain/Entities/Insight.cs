namespace Causely.Domain.Entities;

public class Insight
{
    public Ulid Id { get; set; } = Ulid.NewUlid();

    public Ulid? ErrorClusterId { get; set; }

    public string Summary { get; set; } = string.Empty;

    public string RootCauseText { get; set; } = string.Empty;

    public double ConfidenceScore { get; set; }

    public double ImpactScore { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}
