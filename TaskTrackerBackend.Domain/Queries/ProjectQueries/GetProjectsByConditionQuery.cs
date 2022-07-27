using TaskTrackerBackend.Domain.Dtos;
using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models;

namespace TaskTrackerBackend.Domain.Queries.ProjectQueries;

public sealed class GetProjectsByConditionQuery : IQuery<IEnumerable<Project>>
{
    public GetProjectsByConditionQuery(ProjectCondition condition)
    {
        Condition = condition ?? throw new ArgumentNullException(nameof(condition));
    }

    public ProjectCondition Condition { get; }
}
