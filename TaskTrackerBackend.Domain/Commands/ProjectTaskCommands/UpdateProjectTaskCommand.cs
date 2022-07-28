using TaskTrackerBackend.Domain.Infrastructure.Commands;
using TaskTrackerBackend.Domain.Models;

namespace TaskTrackerBackend.Domain.Commands.ProjectTaskCommands;

public sealed class UpdateProjectTaskCommand : ICommand
{
    public UpdateProjectTaskCommand(Guid projectTaskId, ProjectTask projectTask)
    {
        ProjectTaskId = projectTaskId;
        ProjectTask = projectTask ?? throw new ArgumentNullException(nameof(projectTask));
    }

    public Guid ProjectTaskId { get; }
    public ProjectTask ProjectTask { get; }
}
