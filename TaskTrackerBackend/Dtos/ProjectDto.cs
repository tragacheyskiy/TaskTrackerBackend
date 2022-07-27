using System.ComponentModel.DataAnnotations;
using TaskTrackerBackend.Domain.Models.Enums;

namespace TaskTrackerBackend.Dtos;

public sealed class ProjectDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public int? StartDate { get; set; }
    public int? CompletitionDate { get; set; }
    public ProjectStatus Status { get; set; }
    public int Priority { get; set; }
}

public sealed class NewProjectDto
{
    [Required(AllowEmptyStrings = false), StringLength(256)]
    public string? Name { get; set; }

    [Required, Range(0, 2)]
    public ProjectStatus? Status { get; set; }

    [Required]
    public int? Priority { get; set; }
}
