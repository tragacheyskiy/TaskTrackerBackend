using TaskTrackerBackend.Domain.Dtos;
using TaskTrackerBackend.Domain.Facades.ProjectFacades.Abstractions;
using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Domain.Queries;
using TaskTrackerBackend.Domain.Queries.ProjectQueries;

namespace TaskTrackerBackend.Domain.Facades.ProjectFacades;

public sealed class ProjectQueries : IProjectQueries
{
    private readonly IQueryService<EntityExistsQuery<Project>, bool> _projectExistsService;
    private readonly IQueryService<GetProjectByIdQuery, Project?> _getProjectByIdService;
    private readonly IQueryService<GetProjectsByConditionQuery, IEnumerable<Project>> _getProjectsByConditionService;

    public ProjectQueries(
        IQueryService<EntityExistsQuery<Project>, bool> projectExistsService,
        IQueryService<GetProjectByIdQuery, Project?> getProjectByIdService,
        IQueryService<GetProjectsByConditionQuery, IEnumerable<Project>> getProjectsByConditionService)
    {
        _projectExistsService = projectExistsService ?? throw new ArgumentNullException(nameof(projectExistsService));
        _getProjectByIdService = getProjectByIdService ?? throw new ArgumentNullException(nameof(getProjectByIdService));
        _getProjectsByConditionService = getProjectsByConditionService ?? throw new ArgumentNullException(nameof(getProjectsByConditionService));
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        return _projectExistsService.ExecuteAsync(new EntityExistsQuery<Project>(id));
    }

    public Task<Project?> GetAsync(Guid id)
    {
        return _getProjectByIdService.ExecuteAsync(new GetProjectByIdQuery(id));
    }

    public Task<IEnumerable<Project>> GetAsync(ProjectCondition condition)
    {
        return _getProjectsByConditionService.ExecuteAsync(new GetProjectsByConditionQuery(condition));
    }
}
