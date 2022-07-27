using TaskTrackerBackend.Domain.Commands;
using TaskTrackerBackend.Domain.Infrastructure.Commands;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Domain.Providers.Abstractions;

namespace TaskTrackerBackend.Data.CommandServices.ProjectCommandServices;

public sealed class DeleteProjectCommandService : ICommandService<DeleteEntityCommand<Project>>
{
    private readonly AppDbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;

    public DeleteProjectCommandService(AppDbContext dbContext, IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
    }

    public Task ExecuteAsync(DeleteEntityCommand<Project> command)
    {
        Project project = _dbContext.Projects.Attach(new Project { Id = command.EntityId }).Entity;

        project.DeletedAt = _dateTimeProvider.NowUtc;

        return _dbContext.SaveChangesAsync();
    }
}
