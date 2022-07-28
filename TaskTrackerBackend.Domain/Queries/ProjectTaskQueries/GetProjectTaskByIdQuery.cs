using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models;

namespace TaskTrackerBackend.Domain.Queries.ProjectTaskQueries;

public sealed class GetProjectTaskByIdQuery : IQuery<ProjectTask?>
{
    public GetProjectTaskByIdQuery(Guid projectTaskId)
    {
        ProjectTaskId = projectTaskId;
    }

    public Guid ProjectTaskId { get; }
}
