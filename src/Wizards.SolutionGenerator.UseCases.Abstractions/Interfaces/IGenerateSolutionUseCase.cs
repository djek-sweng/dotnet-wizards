namespace Wizards.SolutionGenerator.UseCases.Abstractions;

public interface IGenerateSolutionUseCase
{
    Task ExecuteAsync(
        string directory,
        string name,
        CancellationToken cancellationToken = default);
}
