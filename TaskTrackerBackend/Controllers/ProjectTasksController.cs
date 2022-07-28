using Microsoft.AspNetCore.Mvc;
using TaskTrackerBackend.Controllers.Abstractions;
using TaskTrackerBackend.Domain.Facades.ProjectTaskFacades.Abstractions;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Dtos;
using TaskTrackerBackend.Mappers;
using TaskTrackerBackend.Validation.Abstractions;

namespace TaskTrackerBackend.Controllers;

[Route("api/tasks")]
public sealed class ProjectTasksController : BaseController
{
    private readonly IProjectTaskCommands _projectTaskCommands;
    private readonly IProjectTaskQueries _projectTaskQueries;
    private readonly IValidationService<NewProjectTaskDto> _validationService;

    public ProjectTasksController(
        IProjectTaskCommands projectTaskCommands,
        IProjectTaskQueries projectTaskQueries,
        IValidationService<NewProjectTaskDto> validationService)
    {
        _projectTaskCommands = projectTaskCommands ?? throw new ArgumentNullException(nameof(projectTaskCommands));
        _projectTaskQueries = projectTaskQueries ?? throw new ArgumentNullException(nameof(projectTaskQueries));
        _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
    }

    [HttpGet]
    public async Task<IEnumerable<ProjectTaskDto>> Get([FromQuery] ProjectTaskConditionDto conditionDto)
    {
        IEnumerable<ProjectTask> result = await _projectTaskQueries.GetAsync(conditionDto.ToModel());
        return result.ToDto();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectTaskDto>> Get(Guid id)
    {
        ProjectTask? result = await _projectTaskQueries.GetAsync(id);

        if (result is null)
            return NotFound();

        return result.ToDto();
    }

    [HttpPost]
    public async Task<ActionResult<EntityIdDto>> Post(NewProjectTaskDto dto)
    {
        IValidationResult validationResult = await _validationService.ValidateAsync(dto);

        if (validationResult.IsFailed)
            return BadRequest();

        Guid result = await _projectTaskCommands.CreateAsync(dto.ToModel());
        return new EntityIdDto(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, NewProjectTaskDto dto)
    {
        bool exists = await _projectTaskQueries.ExistsAsync(id);

        if (!exists)
            return NotFound();

        IValidationResult validationResult = await _validationService.ValidateAsync(dto);

        if (validationResult.IsFailed)
            return BadRequest();

        await _projectTaskCommands.UpdateAsync(id, dto.ToModel());
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        bool exists = await _projectTaskQueries.ExistsAsync(id);

        if (!exists)
            return NotFound();

        await _projectTaskCommands.DeleteAsync(id);
        return NoContent();
    }
}
