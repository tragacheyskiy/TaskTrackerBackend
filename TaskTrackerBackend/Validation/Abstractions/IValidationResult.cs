namespace TaskTrackerBackend.Validation.Abstractions;

public interface IValidationResult
{
    bool IsFailed { get; }
}
