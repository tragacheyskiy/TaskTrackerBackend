using TaskTrackerBackend.Domain.Commands;
using TaskTrackerBackend.Domain.Infrastructure.Commands;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Domain.Providers.Abstractions;

namespace TaskTrackerBackend.Data.CommandServices.ProjectTaskCommandServices;

public sealed class DeleteProjectTaskCommandService : ICommandService<DeleteEntityCommand<ProjectTask>>
{
    private readonly AppDbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;

    public DeleteProjectTaskCommandService(AppDbContext dbContext, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
    }

    public Task ExecuteAsync(DeleteEntityCommand<ProjectTask> command)
    {
        ProjectTask projectTask = _dbContext.ProjectTasks.Attach(new ProjectTask { Id = command.EntityId }).Entity;

        projectTask.DeletedAt = _dateTimeProvider.NowUtc;

        return _dbContext.SaveChangesAsync();
    }
}
