using TaskTrackerBackend.Domain.Dtos.Abstractions;
using TaskTrackerBackend.Domain.Models.Enums;

namespace TaskTrackerBackend.Domain.Dtos;

public sealed class ProjectTaskCondition : SortCondition
{
    public ProjectTaskCondition(
        Guid projectId, string? name, string? description, ProjectTaskStatus? status, int? priorityFrom,
        int? priorityTo, string? data, string? sortBy, bool? isSortAscending) : base(sortBy, isSortAscending ?? true)
    {
        ProjectId = projectId;
        Name = name;
        Description = description;
        Status = status;
        PriorityFrom = priorityFrom;
        PriorityTo = priorityTo;
        Data = data;
    }

    public Guid ProjectId { get; }
    public string? Name { get; }
    public string? Description { get; }
    public ProjectTaskStatus? Status { get; }
    public int? PriorityFrom { get; }
    public int? PriorityTo { get; }
    public string? Data { get; }
}
