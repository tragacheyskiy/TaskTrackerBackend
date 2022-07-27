using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Dtos;

namespace TaskTrackerBackend.Mappers;

internal static class ProjectMapper
{
    public static Project ToModel(this NewProjectDto dto) => new Project
    {
        Name = dto.Name!,
        Status = dto.Status!.Value,
        Priority = dto.Priority!.Value
    };

    public static ProjectDto ToDto(this Project model) => new ProjectDto
    {
        Id = model.Id,
        Name = model.Name,
        StartDate = model.StartDate,
        CompletitionDate = model.CompletitionDate,
        Status = model.Status,
        Priority = model.Priority
    };

    public static IEnumerable<ProjectDto> ToDto(this IEnumerable<Project> models)
    {
        var result = new List<ProjectDto>();

        foreach (Project model in models)
        {
            result.Add(model.ToDto());
        }

        return result;
    }
}
