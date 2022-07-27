using TaskTrackerBackend.Domain.Providers.Abstractions;

namespace TaskTrackerBackend.Domain.Providers;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime NowUtc => DateTime.UtcNow;

    public int NowUtcUnix => (int)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds;
}
