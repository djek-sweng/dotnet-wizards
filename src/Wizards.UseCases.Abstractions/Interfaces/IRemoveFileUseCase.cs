namespace Wizards.UseCases.Abstractions;

public interface IRemoveFileUseCase
{
    Task ExecuteAsync(
        string directory,
        string name,
        CancellationToken cancellationToken = default);
}
