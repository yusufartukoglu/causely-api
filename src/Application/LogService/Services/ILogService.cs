using Causely.Application.LogService.Dtos;

namespace Causely.Application.LogService.Services;

public interface ILogService
{
    Task<int> IngestAsync(List<LogItemDto> logs, CancellationToken cancellationToken = default);
}
