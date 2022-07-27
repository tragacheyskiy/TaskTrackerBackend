using Microsoft.EntityFrameworkCore;
using TaskTrackerBackend.Domain.Dtos;
using TaskTrackerBackend.Domain.Infrastructure.Queries;
using TaskTrackerBackend.Domain.Models;
using TaskTrackerBackend.Domain.Queries.ProjectQueries;

namespace TaskTrackerBackend.Data.QueryServices.ProjectQueryServices;

public sealed class GetProjectsByConditionQueryService : IQueryService<GetProjectsByConditionQuery, IEnumerable<Project>>
{
    private readonly AppDbContext _dbContext;

    public GetProjectsByConditionQueryService(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<Project>> ExecuteAsync(GetProjectsByConditionQuery query)
    {
        ProjectCondition condition = query.Condition;
        var queryable = _dbContext.Projects
            .AsNoTracking()
            .Where(x => x.DeletedAt == null);

        queryable = ApplyFilters(queryable, condition);
        queryable = ApplyOrdering(queryable, condition);

        return await queryable.ToListAsync();
    }

    private IQueryable<Project> ApplyFilters(IQueryable<Project> queryable, ProjectCondition condition)
    {
        if (condition.Name != null)
            queryable = queryable.Where(x => x.Name == condition.Name);

        if (condition.StartDateFrom != null)
            queryable = queryable.Where(x => x.StartDate >= condition.StartDateFrom);

        if (condition.StartDateTo != null)
            queryable = queryable.Where(x => x.StartDate <= condition.StartDateTo);

        if (condition.CompletitionDateFrom != null)
            queryable = queryable.Where(x => x.CompletitionDate >= condition.CompletitionDateFrom);

        if (condition.CompletitionDateTo != null)
            queryable = queryable.Where(x => x.CompletitionDate <= condition.CompletitionDateTo);

        if (condition.Status != null)
            queryable = queryable.Where(x => x.Status == condition.Status);

        if (condition.PriorityFrom != null)
            queryable = queryable.Where(x => x.Priority >= condition.PriorityFrom);

        if (condition.PriorityTo != null)
            queryable = queryable.Where(x => x.Priority <= condition.PriorityTo);

        return queryable;
    }

    private IQueryable<Project> ApplyOrdering(IQueryable<Project> queryable, ProjectCondition condition)
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

        if (sortByUpperInvariant == "STARTDATE")
        {
            return condition.IsSortAscending
                ? queryable.OrderBy(x => x.StartDate)
                : queryable.OrderByDescending(x => x.StartDate);
        }

        if (sortByUpperInvariant == "COMPLETITIONDATE")
        {
            return condition.IsSortAscending
                ? queryable.OrderBy(x => x.CompletitionDate)
                : queryable.OrderByDescending(x => x.CompletitionDate);
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
