namespace TaskTrackerBackend.Domain.Infrastructure.Commands;

public interface ICommandService<TCommand> where TCommand : ICommand
{
    Task ExecuteAsync(TCommand command);
}
