using TaskTrackerBackend.Domain.Commands.ProjectCommands;
using TaskTrackerBackend.Domain.Infrastructure.Commands;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Domain.Providers.Abstractions;

namespace TaskTrackerBackend.Data.CommandServices.ProjectCommandServices;

public sealed class UpdateProjectCommandService : ICommandService<UpdateProjectCommand>
{
    private readonly AppDbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;

    public UpdateProjectCommandService(AppDbContext dbContext, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
    }

    public Task ExecuteAsync(UpdateProjectCommand command)
    {
        Project project = command.Project;

        project.Id = command.ProjectId;
        project.ModifiedAt = _dateTimeProvider.NowUtc;

        return _dbContext.SaveChangesAsync();
    }
}
