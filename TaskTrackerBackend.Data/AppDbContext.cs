using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Domain.Models.Abstractions;

namespace TaskTrackerBackend.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Project> Projects { get; set; } = default!;

    public Task<bool> EntityExistsAsync<TEntity>(Guid id)
    where TEntity : BaseModel
    {
        return Set<TEntity>().AnyAsync(x => x.Id == id && x.DeletedAt == null);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        IEnumerable<IReadOnlyEntityType> entities = modelBuilder.Model.GetEntityTypes();

        foreach (IReadOnlyEntityType entityType in entities)
        {
            if (entityType.ClrType is not null && entityType.ClrType.IsAssignableTo(typeof(BaseModel)))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property("CreatedAt")
                    .HasDefaultValueSql("now()")
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}
