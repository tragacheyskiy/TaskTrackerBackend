namespace TaskTrackerBackend.Domain.Dtos.Abstractions;

public abstract class SortCondition
{
    public SortCondition(string? sortBy, bool isSortAscending)
    {
        SortBy = sortBy;
        IsSortAscending = isSortAscending;
    }

    public string? SortBy { get; }
    public bool IsSortAscending { get; }
}
