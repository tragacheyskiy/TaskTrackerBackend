namespace TaskTrackerBackend.Domain.Providers.Abstractions;

public interface IDateTimeProvider
{
    DateTime NowUtc { get; }
    int NowUtcUnix { get; }
}
