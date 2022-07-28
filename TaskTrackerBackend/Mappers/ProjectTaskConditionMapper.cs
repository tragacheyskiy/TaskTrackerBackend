using TaskTrackerBackend.Domain.Dtos;
using TaskTrackerBackend.Dtos;

namespace TaskTrackerBackend.Mappers;

internal static class ProjectTaskConditionMapper
{
    public static ProjectTaskCondition ToModel(this ProjectTaskConditionDto conditionDto)
    {
        return new ProjectTaskCondition(
            conditionDto.ProjectId!.Value,
            conditionDto.Name,
            conditionDto.Description,
            conditionDto.Status,
            conditionDto.PriorityFrom,
            conditionDto.PriorityTo,
            conditionDto.Data,
            conditionDto.SortBy,
            conditionDto.IsSortAscending);
    }
}
