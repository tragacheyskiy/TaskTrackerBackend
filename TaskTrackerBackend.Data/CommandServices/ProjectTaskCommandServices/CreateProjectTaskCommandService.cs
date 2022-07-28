using TaskTrackerBackend.Domain.Commands.ProjectTaskCommands;
using TaskTrackerBackend.Domain.Infrastructure.Commands;

namespace TaskTrackerBackend.Data.CommandServices.ProjectTaskCommandServices;

public sealed class CreateProjectTaskCommandService : ICommandService<CreateProjectTaskCommand>
{
    private readonly AppDbContext _dbContext;

    public CreateProjectTaskCommandService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public Task ExecuteAsync(CreateProjectTaskCommand command)
    {
        _dbContext.ProjectTasks.Add(command.ProjectTask);
        return _dbContext.SaveChangesAsync();
    }
}
