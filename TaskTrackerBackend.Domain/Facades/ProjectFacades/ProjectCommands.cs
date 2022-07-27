using TaskTrackerBackend.Domain.Commands;
using TaskTrackerBackend.Domain.Commands.ProjectCommands;
using TaskTrackerBackend.Domain.Facades.ProjectFacades.Abstractions;
using TaskTrackerBackend.Domain.Infrastructure.Commands;
using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Domain.Models.Enums;
using TaskTrackerBackend.Domain.Providers.Abstractions;
using TaskTrackerBackend.Domain.Queries.ProjectQueries;

namespace TaskTrackerBackend.Domain.Facades.ProjectFacades;

public sealed class ProjectCommands : IProjectCommands
{
    private readonly ICommandService<CreateProjectCommand> _createProjectService;
    private readonly ICommandService<UpdateProjectCommand> _updateProjectService;
    private readonly ICommandService<DeleteEntityCommand<Project>> _deleteProjectService;
    private readonly IQueryService<GetProjectByIdQuery, Project?> _getProjectService;
    private readonly IDateTimeProvider _dateTimeProvider;

    public ProjectCommands(
        ICommandService<CreateProjectCommand> createProjectService,
        ICommandService<UpdateProjectCommand> updateProjectService,
        ICommandService<DeleteEntityCommand<Project>> deleteProjectService,
        IQueryService<GetProjectByIdQuery, Project?> getProjectService,
        IDateTimeProvider dateTimeProvider)
    {
        _createProjectService = createProjectService ?? throw new ArgumentNullException(nameof(createProjectService));
        _updateProjectService = updateProjectService ?? throw new ArgumentNullException(nameof(updateProjectService));
        _deleteProjectService = deleteProjectService ?? throw new ArgumentNullException(nameof(deleteProjectService));
        _getProjectService = getProjectService ?? throw new ArgumentNullException(nameof(getProjectService));
        _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
    }

    public async Task<Guid> CreateAsync(Project project)
    {
        if (project.Status == ProjectStatus.Active)
            project.StartDate = _dateTimeProvider.NowUtcUnix;

        if (project.Status == ProjectStatus.Completed)
            project.StartDate = project.CompletitionDate = _dateTimeProvider.NowUtcUnix;

        await _createProjectService.ExecuteAsync(new CreateProjectCommand(project));
        return project.Id;
    }

    public Task DeleteAsync(Guid id)
    {
        return _deleteProjectService.ExecuteAsync(new DeleteEntityCommand<Project>(id));
    }

    public async Task UpdateAsync(Guid id, Project project)
    {
        Project existingProject = (await _getProjectService.ExecuteAsync(new GetProjectByIdQuery(id)))!;

        if (project.Status == ProjectStatus.Active && existingProject.StartDate is null)
            project.StartDate = _dateTimeProvider.NowUtcUnix;

        if (project.Status == ProjectStatus.Completed)
        {
            project.StartDate = existingProject.StartDate;
            project.CompletitionDate = _dateTimeProvider.NowUtcUnix;
        }

        await _updateProjectService.ExecuteAsync(new UpdateProjectCommand(id, project));
    }
}
