namespace Wizards.UseCases.Abstractions;

public interface IDeserializeJsonUseCase
{
    Task<T?> ExecuteAsync<T>(
        string jsonString,
        CancellationToken cancellationToken = default);
}
