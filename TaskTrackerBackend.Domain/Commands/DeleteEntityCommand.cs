using TaskTrackerBackend.Domain.Infrastructure.Commands;
using TaskTrackerBackend.Domain.Models.Abstractions;

namespace TaskTrackerBackend.Domain.Commands;

public sealed class DeleteEntityCommand<TEntity> : ICommand where TEntity : BaseModel
{
    public DeleteEntityCommand(Guid entityId)
    {
        EntityId = entityId;
    }

    public Guid EntityId { get; }
}
