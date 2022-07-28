using TaskTrackerBackend.Domain.Infrastructure.Commands;
using TaskTrackerBackend.Domain.Models;

namespace TaskTrackerBackend.Domain.Commands.ProjectTaskCommands;

public sealed class CreateProjectTaskCommand : ICommand
{
    public CreateProjectTaskCommand(ProjectTask projectTask)
    {
        ProjectTask = projectTask ?? throw new ArgumentNullException(nameof(projectTask));
    }

    public ProjectTask ProjectTask { get; }
}
