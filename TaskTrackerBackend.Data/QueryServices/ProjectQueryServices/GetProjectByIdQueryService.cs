using Microsoft.EntityFrameworkCore;
using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Domain.Queries.ProjectQueries;

namespace TaskTrackerBackend.Data.QueryServices.ProjectQueryServices;

public sealed class GetProjectByIdQueryService : IQueryService<GetProjectByIdQuery, Project?>
{
    private readonly AppDbContext _dbContext;

    public GetProjectByIdQueryService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public Task<Project?> ExecuteAsync(GetProjectByIdQuery query)
    {
        return _dbContext.Projects
            .AsNoTracking()
            .Where(x => x.DeletedAt == null)
            .FirstOrDefaultAsync(x => x.Id == query.ProjectId);
    }
}
