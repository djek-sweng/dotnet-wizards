namespace Wizards.SolutionGenerator.UseCases.Abstractions;

public interface IGenerateSolutionFromDirectoryUseCase
{
    Task ExecuteAsync(
        string directory,
        string name,
        CancellationToken cancellationToken = default);
}
