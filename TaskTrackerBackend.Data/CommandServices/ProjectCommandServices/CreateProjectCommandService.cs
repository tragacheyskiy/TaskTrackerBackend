using TaskTrackerBackend.Domain.Commands.ProjectCommands;
using TaskTrackerBackend.Domain.Infrastructure.Commands;

namespace TaskTrackerBackend.Data.CommandServices.ProjectCommandServices;

public sealed class CreateProjectCommandService : ICommandService<CreateProjectCommand>
{
    private readonly AppDbContext _dbContext;

    public CreateProjectCommandService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public Task ExecuteAsync(CreateProjectCommand command)
    {
        _dbContext.Projects.Add(command.Project);
        return _dbContext.SaveChangesAsync();
    }
}
