using System.ComponentModel.DataAnnotations;
using TaskTrackerBackend.Domain.Models.Enums;
using TaskTrackerBackend.Dtos.Abstractions;

namespace TaskTrackerBackend.Dtos;

public sealed class ProjectTaskConditionDto : SortConditionDto
{
    [Required]
    public Guid? ProjectId { get; set; }

    [StringLength(256)]
    public string? Name { get; set; }

    [StringLength(256)]
    public string? Description { get; set; }

    [Range(0, 2)]
    public ProjectTaskStatus? Status { get; set; }

    public int? PriorityFrom { get; set; }
    public int? PriorityTo { get; set; }
    public string? Data { get; set; }
}
