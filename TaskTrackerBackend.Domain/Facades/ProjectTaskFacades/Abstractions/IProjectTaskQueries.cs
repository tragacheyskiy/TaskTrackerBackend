using TaskTrackerBackend.Domain.Dtos;
using TaskTrackerBackend.Domain.Models;

namespace TaskTrackerBackend.Domain.Facades.ProjectTaskFacades.Abstractions;

public interface IProjectTaskQueries
{
    Task<bool> ExistsAsync(Guid id);
    Task<ProjectTask?> GetAsync(Guid id);
    Task<IEnumerable<ProjectTask>> GetAsync(ProjectTaskCondition condition);
}
