using TaskTrackerBackend.Domain.Dtos;
using TaskTrackerBackend.Dtos;

namespace TaskTrackerBackend.Mappers;

internal static class ProjectConditionMapper
{
    public static ProjectCondition ToModel(this ProjectConditionDto conditionDto)
    {
        return new ProjectCondition(
            conditionDto.Name,
            conditionDto.StartDateFrom,
            conditionDto.StartDateTo,
            conditionDto.CompletitionDateFrom,
            conditionDto.CompletitionDateTo,
            conditionDto.Status,
            conditionDto.PriorityFrom,
            conditionDto.PriorityTo,
            conditionDto.SortBy,
            conditionDto.IsSortAscending);
    }
}
