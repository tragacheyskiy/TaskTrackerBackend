using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models.Abstractions;
using TaskTrackerBackend.Domain.Queries;

namespace TaskTrackerBackend.Data.QueryServices;

public sealed class EntityExistsQueryService<TEntity> : IQueryService<EntityExistsQuery<TEntity>, bool> where TEntity : BaseModel
{
    private readonly AppDbContext _dbContext;

    public EntityExistsQueryService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public Task<bool> ExecuteAsync(EntityExistsQuery<TEntity> query)
    {
        return _dbContext.EntityExistsAsync<TEntity>(query.EntityId);
    }
}
