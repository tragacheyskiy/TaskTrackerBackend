namespace TaskTrackerBackend.Validation.Abstractions;

internal abstract class ValidationService<TDto> : IValidationService<TDto> where TDto : class, new()
{
    private sealed class ValidationResultInner : IValidationResult
    {
        public ValidationResultInner(bool isFailed)
        {
            IsFailed = isFailed;
        }

        public bool IsFailed { get; }
    }

    public abstract Task<IValidationResult> ValidateAsync(TDto dto);

    protected IValidationResult ValidationResult(bool isFailed) => new ValidationResultInner(isFailed);
}
