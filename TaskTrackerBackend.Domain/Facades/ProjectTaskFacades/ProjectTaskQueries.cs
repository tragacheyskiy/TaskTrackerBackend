using TaskTrackerBackend.Domain.Dtos;
using TaskTrackerBackend.Domain.Facades.ProjectTaskFacades.Abstractions;
using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Domain.Queries;
using TaskTrackerBackend.Domain.Queries.ProjectTaskQueries;

namespace TaskTrackerBackend.Domain.Facades.ProjectTaskFacades;

public sealed class ProjectTaskQueries : IProjectTaskQueries
{
    private readonly IQueryService<EntityExistsQuery<ProjectTask>, bool> _projectTaskExistsService;
    private readonly IQueryService<GetProjectTaskByIdQuery, ProjectTask?> _getProjectTaskByIdService;
    private readonly IQueryService<GetProjectTasksByConditionQuery, IEnumerable<ProjectTask>> _getProjectTasksByConditionService;

    public ProjectTaskQueries(
        IQueryService<EntityExistsQuery<ProjectTask>, bool> projectTaskExistsService,
        IQueryService<GetProjectTaskByIdQuery, ProjectTask?> getProjectTaskByIdService,
        IQueryService<GetProjectTasksByConditionQuery, IEnumerable<ProjectTask>> getProjectTasksByConditionService)
    {
        _projectTaskExistsService = projectTaskExistsService ?? throw new ArgumentNullException(nameof(projectTaskExistsService));
        _getProjectTaskByIdService = getProjectTaskByIdService ?? throw new ArgumentNullException(nameof(getProjectTaskByIdService));
        _getProjectTasksByConditionService = getProjectTasksByConditionService ?? throw new ArgumentNullException(nameof(getProjectTasksByConditionService));
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        return _projectTaskExistsService.ExecuteAsync(new EntityExistsQuery<ProjectTask>(id));
    }

    public Task<ProjectTask?> GetAsync(Guid id)
    {
        return _getProjectTaskByIdService.ExecuteAsync(new GetProjectTaskByIdQuery(id));
    }

    public Task<IEnumerable<ProjectTask>> GetAsync(ProjectTaskCondition condition)
    {
        return _getProjectTasksByConditionService.ExecuteAsync(new GetProjectTasksByConditionQuery(condition));
    }
}
