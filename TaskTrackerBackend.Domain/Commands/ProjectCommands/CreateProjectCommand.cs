using TaskTrackerBackend.Domain.Infrastructure.Commands;
using TaskTrackerBackend.Domain.Models;

namespace TaskTrackerBackend.Domain.Commands.ProjectCommands;

public sealed class CreateProjectCommand : ICommand
{
    public CreateProjectCommand(Project project)
    {
        Project = project ?? throw new ArgumentNullException(nameof(project));
    }

    public Project Project { get; }
}
