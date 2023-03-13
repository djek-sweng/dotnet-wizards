namespace Wizards.SolutionGenerator.UseCases.Abstractions;

public interface IGenerateSolutionUseCase
{
    Task ExecuteAsync(
        string path,
        string name,
        CancellationToken cancellationToken = default);
}
