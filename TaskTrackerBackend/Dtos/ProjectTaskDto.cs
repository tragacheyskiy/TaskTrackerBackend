using System.ComponentModel.DataAnnotations;
using TaskTrackerBackend.Domain.Models.Enums;

namespace TaskTrackerBackend.Dtos;

public sealed class ProjectTaskDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Guid ProjectId { get; set; }
    public ProjectTaskStatus? Status { get; set; }
    public int? Priority { get; set; }
    public string? Data { get; set; }
}

public sealed class NewProjectTaskDto
{
    [Required(AllowEmptyStrings = false), StringLength(256)]
    public string Name { get; set; } = default!;

    [Required(AllowEmptyStrings = false), StringLength(256)]
    public string? Description { get; set; } = default!;

    [Required]
    public Guid? ProjectId { get; set; }

    [Range(0, 2)]
    public ProjectTaskStatus? Status { get; set; }

    public int? Priority { get; set; }
    public string? Data { get; set; }
}
