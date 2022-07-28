namespace TaskTrackerBackend.Validation.Abstractions;

public interface IValidationService<TDto> where TDto : class, new()
{
    Task<IValidationResult> ValidateAsync(TDto dto);
}
