using TaskTrackerBackend.Domain.Dtos;
using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models;

namespace TaskTrackerBackend.Domain.Queries.ProjectTaskQueries;

public sealed class GetProjectTasksByConditionQuery : IQuery<IEnumerable<ProjectTask>>
{
    public GetProjectTasksByConditionQuery(ProjectTaskCondition condition)
    {
        Condition = condition ?? throw new ArgumentNullException(nameof(condition));
    }

    public ProjectTaskCondition Condition { get; }
}
