namespace TaskTrackerBackend.Dtos;

public abstract class SortConditionDto
{
    public string? SortBy { get; set; }
    public bool? IsSortAscending { get; set; }
}
