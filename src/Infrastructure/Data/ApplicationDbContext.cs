using System.Reflection;
using Causely.Application.Common.Interfaces;
using Causely.Domain.Entities;
using Causely.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Causely.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public DbSet<LogEntry> LogEntries => Set<LogEntry>();

    public DbSet<ErrorCluster> ErrorClusters => Set<ErrorCluster>();

    public DbSet<Deployment> Deployments => Set<Deployment>();

    public DbSet<Insight> Insights => Set<Insight>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
