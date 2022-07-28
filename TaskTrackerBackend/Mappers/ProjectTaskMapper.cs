using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Dtos;

namespace TaskTrackerBackend.Mappers;

internal static class ProjectTaskMapper
{
    public static ProjectTask ToModel(this NewProjectTaskDto dto) => new ProjectTask
    {
        Name = dto.Name,
        Description = dto.Description!,
        ProjectId = dto.ProjectId!.Value,
        Status = dto.Status,
        Priority = dto.Priority,
        Data = dto.Data
    };

    public static ProjectTaskDto ToDto(this ProjectTask model) => new ProjectTaskDto
    {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description,
        ProjectId = model.ProjectId,
        Status = model.Status,
        Priority = model.Priority,
        Data = model.Data
    };

    public static IEnumerable<ProjectTaskDto> ToDto(this IEnumerable<ProjectTask> models)
    {
        var result = new List<ProjectTaskDto>();

        foreach (ProjectTask model in models)
        {
            result.Add(model.ToDto());
        }

        return result;
    }
}
