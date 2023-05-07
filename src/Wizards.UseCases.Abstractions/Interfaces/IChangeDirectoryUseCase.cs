namespace Wizards.UseCases.Abstractions;

public interface IChangeDirectoryUseCase
{
    Task Execute(
        string directory,
        CancellationToken cancellationToken = default);
}
