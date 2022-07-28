using TaskTrackerBackend.Domain.Commands.ProjectTaskCommands;
using TaskTrackerBackend.Domain.Infrastructure.Commands;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Domain.Providers.Abstractions;

namespace TaskTrackerBackend.Data.CommandServices.ProjectTaskCommandServices;

public sealed class UpdateProjectTaskCommandService : ICommandService<UpdateProjectTaskCommand>
{
    private readonly AppDbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;

    public UpdateProjectTaskCommandService(AppDbContext dbContext, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
    }

    public Task ExecuteAsync(UpdateProjectTaskCommand command)
    {
        ProjectTask projectTask = command.ProjectTask;

        projectTask.Id = command.ProjectTaskId;
        projectTask.ModifiedAt = _dateTimeProvider.NowUtc;

        return _dbContext.SaveChangesAsync();
    }
}
