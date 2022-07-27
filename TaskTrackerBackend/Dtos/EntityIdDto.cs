namespace TaskTrackerBackend.Dtos;

public sealed class EntityIdDto
{
    public EntityIdDto(Guid entityId)
    {
        EntityId = entityId;
    }

    public Guid EntityId { get; }
}
