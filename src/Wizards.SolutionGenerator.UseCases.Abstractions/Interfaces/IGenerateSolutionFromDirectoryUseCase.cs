namespace Wizards.SolutionGenerator.UseCases.Abstractions;

public interface IGenerateSolutionFromDirectoryUseCase
{
    Task ExecuteAsync(
        string directory,
        string solutionName,
        CancellationToken cancellationToken = default);
}
