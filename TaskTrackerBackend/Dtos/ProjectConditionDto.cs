using System.ComponentModel.DataAnnotations;
using TaskTrackerBackend.Domain.Models.Enums;

namespace TaskTrackerBackend.Dtos;

public sealed class ProjectConditionDto : SortConditionDto
{
    [StringLength(256)]
    public string? Name { get; set; }

    [Range(0, 2)]
    public ProjectStatus? Status { get; set; }

    public int? StartDateFrom { get; set; }
    public int? StartDateTo { get; set; }
    public int? CompletitionDateFrom { get; set; }
    public int? CompletitionDateTo { get; set; }
    public int? PriorityFrom { get; set; }
    public int? PriorityTo { get; set; }
}
