using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskTrackerBackend.Domain.Models.Abstractions;
using TaskTrackerBackend.Domain.Models.Enums;

namespace TaskTrackerBackend.Domain.Models;

[Table("project")]
public sealed class Project : BaseModel
{
    [Column("name"), StringLength(256)]
    public string Name { get; set; } = default!;

    [Column("start_date")]
    public int? StartDate { get; set; }

    [Column("completition_date")]
    public int? CompletitionDate { get; set; }

    [Column("status")]
    public ProjectStatus Status { get; set; }

    [Column("priority")]
    public int Priority { get; set; }
}
