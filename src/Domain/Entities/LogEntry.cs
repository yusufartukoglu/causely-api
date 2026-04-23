namespace Causely.Domain.Entities;

public class LogEntry
{
    public Ulid Id { get; set; } = Ulid.NewUlid();

    public DateTime Timestamp { get; set; }

    public string Service { get; set; } = string.Empty;

    public string Environment { get; set; } = string.Empty;

    public string Level { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public string? ExceptionType { get; set; }

    public string? StackTrace { get; set; }

    public string? Endpoint { get; set; }

    public string? TraceId { get; set; }

    public DateTime CreatedAt { get; set; }
}
