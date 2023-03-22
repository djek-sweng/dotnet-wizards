namespace Wizards.UseCases.Abstractions;

public interface IJumpToDirectoryUseCase
{
    Task Execute(
        string directory,
        CancellationToken cancellationToken = default);
}
