namespace Wizards.SolutionGenerator.UseCases.Abstractions;

public interface IGenerateMakefileUseCase
{
    Task ExecuteAsync(
        string directory,
        string name,
        CancellationToken cancellationToken = default);
}
