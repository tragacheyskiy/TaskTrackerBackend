using Microsoft.EntityFrameworkCore;
using TaskTrackerBackend.Domain.Dtos;
using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Domain.Queries.ProjectTaskQueries;

namespace TaskTrackerBackend.Data.QueryServices.ProjectTaskQueryServices;

public sealed class GetProjectTasksByConditionQueryService : IQueryService<GetProjectTasksByConditionQuery, IEnumerable<ProjectTask>>
{
    private readonly AppDbContext _dbContext;

    public GetProjectTasksByConditionQueryService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<ProjectTask>> ExecuteAsync(GetProjectTasksByConditionQuery query)
    {
        ProjectTaskCondition condition = query.Condition;

        var queryable = _dbContext.ProjectTasks
            .AsNoTracking()
            .Where(x => x.ProjectId == condition.ProjectId && x.DeletedAt == null);

        queryable = ApplyFilters(queryable, condition);
        queryable = ApplyOrdering(queryable, condition);

        return await queryable.ToListAsync();
    }

    private IQueryable<ProjectTask> ApplyFilters(IQueryable<ProjectTask> queryable, ProjectTaskCondition condition)
    {
        if (condition.Name != null)
            queryable = queryable.Where(x => x.Name == condition.Name);

        if (condition.Description != null)
            queryable = queryable.Where(x => x.Description == condition.Description);

        if (condition.Status != null)
            queryable = queryable.Where(x => x.Status == condition.Status);

        if (condition.PriorityFrom != null)
            queryable = queryable.Where(x => x.Priority >= condition.PriorityFrom);

        if (condition.PriorityTo != null)
            queryable = queryable.Where(x => x.Priority <= condition.PriorityTo);

        if (condition.Data != null)
            queryable = queryable.Where(x => EF.Functions.JsonContains(x.Data!, condition.Data));

        return queryable;
    }

    private IQueryable<ProjectTask> ApplyOrdering(IQueryable<ProjectTask> queryable, ProjectTaskCondition condition)
    {
        if (string.IsNullOrWhiteSpace(condition.SortBy))
            return queryable;

        string sortByUpperInvariant = condition.SortBy.ToUpperInvariant();

        if (sortByUpperInvariant == "ID")
        {
            return condition.IsSortAscending
                ? queryable.OrderBy(x => x.Id)
                : queryable.OrderByDescending(x => x.Id);
        }

        if (sortByUpperInvariant == "NAME")
        {
            return condition.IsSortAscending
                ? queryable.OrderBy(x => x.Name)
                : queryable.OrderByDescending(x => x.Name);
        }

        if (sortByUpperInvariant == "DESCRIPTION")
        {
            return condition.IsSortAscending
                ? queryable.OrderBy(x => x.Description)
                : queryable.OrderByDescending(x => x.Description);
        }

        if (sortByUpperInvariant == "STATUS")
        {
            return condition.IsSortAscending
                ? queryable.OrderBy(x => x.Status)
                : queryable.OrderByDescending(x => x.Status);
        }

        if (sortByUpperInvariant == "PRIORITY")
        {
            return condition.IsSortAscending
                ? queryable.OrderBy(x => x.Priority)
                : queryable.OrderByDescending(x => x.Priority);
        }

        return queryable;
    }
}
