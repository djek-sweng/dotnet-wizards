namespace Wizards.UseCases.Abstractions;

public interface IWriteFileUseCase
{
    Task ExecuteAsync(
        string path,
        string content,
        CancellationToken cancellationToken = default);
}
