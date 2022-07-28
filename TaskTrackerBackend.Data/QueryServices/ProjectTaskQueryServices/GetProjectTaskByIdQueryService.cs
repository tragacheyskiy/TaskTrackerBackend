using Microsoft.EntityFrameworkCore;
using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Domain.Queries.ProjectTaskQueries;

namespace TaskTrackerBackend.Data.QueryServices.ProjectTaskQueryServices;

public sealed class GetProjectTaskByIdQueryService : IQueryService<GetProjectTaskByIdQuery, ProjectTask?>
{
    private readonly AppDbContext _dbContext;

    public GetProjectTaskByIdQueryService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public Task<ProjectTask?> ExecuteAsync(GetProjectTaskByIdQuery query)
    {
        return _dbContext.ProjectTasks
            .AsNoTracking()
            .Where(x => x.DeletedAt == null)
            .FirstOrDefaultAsync(x => x.Id == query.ProjectTaskId);
    }
}
