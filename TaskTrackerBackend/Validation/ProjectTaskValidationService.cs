using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Domain.Queries;
using TaskTrackerBackend.Dtos;
using TaskTrackerBackend.Validation.Abstractions;

namespace TaskTrackerBackend.Validation;

internal sealed class ProjectTaskValidationService : ValidationService<NewProjectTaskDto>
{
    private readonly IQueryService<EntityExistsQuery<Project>, bool> _projectExistsService;

    public ProjectTaskValidationService(IQueryService<EntityExistsQuery<Project>, bool> projectExistsService)
    {
        _projectExistsService = projectExistsService ?? throw new ArgumentNullException(nameof(projectExistsService));
    }

    public override async Task<IValidationResult> ValidateAsync(NewProjectTaskDto dto)
    {
        bool exists = await _projectExistsService.ExecuteAsync(new EntityExistsQuery<Project>(dto.ProjectId!.Value));
        return ValidationResult(!exists);
    }
}
