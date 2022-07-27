using TaskTrackerBackend.Domain.Infrastructure.Commands;
using TaskTrackerBackend.Domain.Models;

namespace TaskTrackerBackend.Domain.Commands.ProjectCommands;

public sealed class UpdateProjectCommand : ICommand
{
    public UpdateProjectCommand(Guid projectId, Project project)
    {
        ProjectId = projectId;
        Project = project ?? throw new ArgumentNullException(nameof(project));
    }

    public Guid ProjectId { get; }
    public Project Project { get; }
}
