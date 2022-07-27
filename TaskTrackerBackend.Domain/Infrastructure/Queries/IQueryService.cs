namespace TaskTrackerBackend.Domain.Infrastructure.Queries;

public interface IQueryService<TQuery, TResult> where TQuery : IQuery<TResult>
{
    Task<TResult> ExecuteAsync(TQuery query);
}
