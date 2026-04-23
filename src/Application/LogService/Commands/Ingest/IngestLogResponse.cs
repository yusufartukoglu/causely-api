namespace Causely.Application.LogService.Commands.Ingest;

public class IngestLogResponse
{
    public int AcceptedCount { get; set; }

    public string Message { get; set; } = string.Empty;
}
