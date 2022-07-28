using TaskTrackerBackend.Domain.Commands;
using TaskTrackerBackend.Domain.Commands.ProjectTaskCommands;
using TaskTrackerBackend.Domain.Facades.ProjectTaskFacades.Abstractions;
using TaskTrackerBackend.Domain.Infrastructure.Commands;
using TaskTrackerBackend.Domain.Models;

namespace TaskTrackerBackend.Domain.Facades.ProjectTaskFacades;

public sealed class ProjectTaskCommands : IProjectTaskCommands
{
    private readonly ICommandService<CreateProjectTaskCommand> _createProjectTaskService;
    private readonly ICommandService<UpdateProjectTaskCommand> _updateProjectTaskService;
    private readonly ICommandService<DeleteEntityCommand<ProjectTask>> _deleteProjectTaskService;

    public ProjectTaskCommands(
        ICommandService<CreateProjectTaskCommand> createProjectTaskService,
        ICommandService<UpdateProjectTaskCommand> updateProjectTaskService,
        ICommandService<DeleteEntityCommand<ProjectTask>> deleteProjectTaskService)
    {
        _createProjectTaskService = createProjectTaskService ?? throw new ArgumentNullException(nameof(createProjectTaskService));
        _updateProjectTaskService = updateProjectTaskService ?? throw new ArgumentNullException(nameof(updateProjectTaskService));
        _deleteProjectTaskService = deleteProjectTaskService ?? throw new ArgumentNullException(nameof(deleteProjectTaskService));
    }

    public async Task<Guid> CreateAsync(ProjectTask projectTask)
    {
        await _createProjectTaskService.ExecuteAsync(new CreateProjectTaskCommand(projectTask));
        return projectTask.Id;
    }

    public Task DeleteAsync(Guid id)
    {
        return _deleteProjectTaskService.ExecuteAsync(new DeleteEntityCommand<ProjectTask>(id));
    }

    public Task UpdateAsync(Guid id, ProjectTask projectTask)
    {
        return _updateProjectTaskService.ExecuteAsync(new UpdateProjectTaskCommand(id, projectTask));
    }
}
