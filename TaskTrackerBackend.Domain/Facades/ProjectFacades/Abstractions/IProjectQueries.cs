using TaskTrackerBackend.Domain.Dtos;
using TaskTrackerBackend.Domain.Models;

namespace TaskTrackerBackend.Domain.Facades.ProjectFacades.Abstractions;

public interface IProjectQueries
{
    Task<bool> ExistsAsync(Guid id);
    Task<Project?> GetAsync(Guid id);
    Task<IEnumerable<Project>> GetAsync(ProjectCondition condition);
}
