using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models;

namespace TaskTrackerBackend.Domain.Queries.ProjectQueries;

public sealed class GetProjectByIdQuery : IQuery<Project?>
{
    public GetProjectByIdQuery(Guid projectId)
    {
        ProjectId = projectId;
    }

    public Guid ProjectId { get; }
}
