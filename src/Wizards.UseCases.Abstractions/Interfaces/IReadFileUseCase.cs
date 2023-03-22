namespace Wizards.UseCases.Abstractions;

public interface IReadFileUseCase
{
    Task<string> ExecuteAsync(
        string path,
        CancellationToken cancellationToken = default);
}
