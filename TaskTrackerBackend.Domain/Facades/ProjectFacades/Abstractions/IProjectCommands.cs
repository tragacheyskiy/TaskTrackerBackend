using TaskTrackerBackend.Domain.Models;

namespace TaskTrackerBackend.Domain.Facades.ProjectFacades.Abstractions;

public interface IProjectCommands
{
    Task<Guid> CreateAsync(Project project);
    Task UpdateAsync(Guid id, Project project);
    Task DeleteAsync(Guid id);
}
