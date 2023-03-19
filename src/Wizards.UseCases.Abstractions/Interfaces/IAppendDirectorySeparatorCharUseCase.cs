namespace Wizards.UseCases.Abstractions;

public interface IAppendDirectorySeparatorCharUseCase
{
    Task<string> ExecuteAsync(
        string directory,
        CancellationToken cancellationToken = default);
}
