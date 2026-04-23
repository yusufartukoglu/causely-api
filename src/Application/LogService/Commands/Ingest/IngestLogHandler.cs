using Causely.Application.Common.Interfaces;
using Causely.Application.LogService.Rules;
using Causely.Domain.Entities;

namespace Causely.Application.LogService.Commands.Ingest;

public class IngestLogHandler : IRequestHandler<IngestLogRequest, IngestLogResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly LogBusiness _logBusiness;

    public IngestLogHandler(IApplicationDbContext context, LogBusiness logBusiness)
    {
        _context = context;
        _logBusiness = logBusiness;
    }

    public async Task<IngestLogResponse> Handle(IngestLogRequest request, CancellationToken cancellationToken)
    {
        _logBusiness.CheckLogsMustExist(request.Logs);

        var count = request.Logs.Count;
        var createdAt = DateTime.UtcNow;
        var logEntries = request.Logs.Select(log => new LogEntry
        {
            Timestamp = log.Timestamp,
            Service = log.Service,
            Environment = log.Environment,
            Level = log.Level,
            Message = log.Message,
            ExceptionType = log.ExceptionType,
            StackTrace = log.StackTrace,
            Endpoint = log.Endpoint,
            TraceId = log.TraceId,
            CreatedAt = createdAt
        }).ToList();

        await _context.LogEntries.AddRangeAsync(logEntries, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new IngestLogResponse
        {
            AcceptedCount = count,
            Message = $"{count} log item(s) accepted."
        };
    }
}
