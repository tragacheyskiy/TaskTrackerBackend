using TaskTrackerBackend.Domain.Models.Enums;

namespace TaskTrackerBackend.Domain.Dtos;

public sealed class ProjectCondition : SortCondition
{
    public ProjectCondition(
        string? name, int? startDateFrom, int? startDateTo, int? completitionDateFrom, int? completitionDateTo,
        ProjectStatus? status, int? priorityFrom, int? priorityTo, string? sortBy, bool? isSortAscending) : base(sortBy, isSortAscending ?? true)
    {
        Name = name;
        StartDateFrom = startDateFrom;
        StartDateTo = startDateTo;
        CompletitionDateFrom = completitionDateFrom;
        CompletitionDateTo = completitionDateTo;
        Status = status;
        PriorityFrom = priorityFrom;
        PriorityTo = priorityTo;
    }

    public string? Name { get; }
    public int? StartDateFrom { get; }
    public int? StartDateTo { get; }
    public int? CompletitionDateFrom { get; }
    public int? CompletitionDateTo { get; }
    public ProjectStatus? Status { get; }
    public int? PriorityFrom { get; }
    public int? PriorityTo { get; }
}
