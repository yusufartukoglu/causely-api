using Causely.Application.LogService.Dtos;

namespace Causely.Application.LogService.Commands.Ingest;

public class IngestLogRequest : IRequest<IngestLogResponse>
{
    public List<LogItemDto> Logs { get; set; } = new();
}
