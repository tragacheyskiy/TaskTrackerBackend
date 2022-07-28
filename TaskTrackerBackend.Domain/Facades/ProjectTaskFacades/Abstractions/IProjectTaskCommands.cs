using TaskTrackerBackend.Domain.Models;

namespace TaskTrackerBackend.Domain.Facades.ProjectTaskFacades.Abstractions;

public interface IProjectTaskCommands
{
    Task<Guid> CreateAsync(ProjectTask projectTask);
    Task UpdateAsync(Guid id, ProjectTask projectTask);
    Task DeleteAsync(Guid id);
}
