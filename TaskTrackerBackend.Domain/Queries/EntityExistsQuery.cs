using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models.Abstractions;

namespace TaskTrackerBackend.Domain.Queries;

public sealed class EntityExistsQuery<TEntity> : IQuery<bool> where TEntity : BaseModel
{
    public EntityExistsQuery(Guid entityId)
    {
        EntityId = entityId;
    }

    public Guid EntityId { get; }
}
