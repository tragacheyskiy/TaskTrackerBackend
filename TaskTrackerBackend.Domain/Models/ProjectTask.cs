using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskTrackerBackend.Domain.Models.Abstractions;
using TaskTrackerBackend.Domain.Models.Enums;

namespace TaskTrackerBackend.Domain.Models;

[Table("project_task")]
public sealed class ProjectTask : BaseModel
{
    [Column("name"), StringLength(256)]
    public string Name { get; set; } = default!;

    [Column("description"), StringLength(256)]
    public string Description { get; set; } = default!;

    [Column("project_id")]
    public Guid ProjectId { get; set; }

    [Column("status")]
    public ProjectTaskStatus? Status { get; set; }

    [Column("priority")]
    public int? Priority { get; set; }

    [Column("data", TypeName = "jsonb")]
    public string? Data { get; set; }
}
