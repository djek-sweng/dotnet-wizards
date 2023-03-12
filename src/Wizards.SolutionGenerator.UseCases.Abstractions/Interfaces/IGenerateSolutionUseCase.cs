namespace Wizards.SolutionGenerator.UseCases.Abstractions;

public interface IGenerateSolutionUseCase
{
    Task ExecuteAsync(
        string path,
        CancellationToken cancellationToken = default);
}
