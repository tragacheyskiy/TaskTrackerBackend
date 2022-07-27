using Microsoft.AspNetCore.Mvc;
using TaskTrackerBackend.Controllers.Abstractions;
using TaskTrackerBackend.Domain.Facades.ProjectFacades.Abstractions;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Dtos;
using TaskTrackerBackend.Mappers;

namespace TaskTrackerBackend.Controllers;

[Route("api/projects")]
public sealed class ProjectsController : BaseController
{
    private readonly IProjectCommands _projectCommands;
    private readonly IProjectQueries _projectQueries;

    public ProjectsController(IProjectCommands projectCommands, IProjectQueries projectQueries)
    {
        _projectCommands = projectCommands ?? throw new ArgumentNullException(nameof(projectCommands));
        _projectQueries = projectQueries ?? throw new ArgumentNullException(nameof(projectQueries));
    }

    [HttpGet]
    public async Task<IEnumerable<ProjectDto>> Get([FromQuery] ProjectConditionDto conditionDto)
    {
        IEnumerable<Project> result = await _projectQueries.GetAsync(conditionDto.ToModel());
        return result.ToDto();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectDto>> Get(Guid id)
    {
        Project? result = await _projectQueries.GetAsync(id);

        if (result is null)
            return NotFound();

        return result.ToDto();
    }

    [HttpPost]
    public async Task<EntityIdDto> Post(NewProjectDto dto)
    {
        Guid result = await _projectCommands.CreateAsync(dto.ToModel());
        return new EntityIdDto(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, NewProjectDto dto)
    {
        bool exists = await _projectQueries.ExistsAsync(id);

        if (!exists)
            return NotFound();

        await _projectCommands.UpdateAsync(id, dto.ToModel());
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        bool exists = await _projectQueries.ExistsAsync(id);

        if (!exists)
            return NotFound();

        await _projectCommands.DeleteAsync(id);
        return NoContent();
    }
}
