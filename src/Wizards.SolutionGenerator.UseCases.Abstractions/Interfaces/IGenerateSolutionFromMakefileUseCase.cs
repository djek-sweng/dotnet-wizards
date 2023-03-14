namespace Wizards.SolutionGenerator.UseCases.Abstractions;

public interface IGenerateSolutionFromMakefileUseCase
{
    Task ExecuteAsync(
        string makefilePath,
        string name,
        CancellationToken cancellationToken = default);
}
