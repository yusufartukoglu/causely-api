using Causely.Domain.Entities;

namespace Causely.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<LogEntry> LogEntries { get; }

    DbSet<ErrorCluster> ErrorClusters { get; }

    DbSet<Deployment> Deployments { get; }

    DbSet<Insight> Insights { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
