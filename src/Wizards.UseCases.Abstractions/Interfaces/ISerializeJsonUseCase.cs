namespace Wizards.UseCases.Abstractions;

public interface ISerializeJsonUseCase
{
    Task<string> ExecuteAsync(
        object jsonObject,
        CancellationToken cancellationToken = default);
}
