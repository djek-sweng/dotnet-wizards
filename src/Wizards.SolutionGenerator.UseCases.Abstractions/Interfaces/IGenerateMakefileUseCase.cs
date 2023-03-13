namespace Wizards.SolutionGenerator.UseCases.Abstractions;

public interface IGenerateMakefileUseCase
{
    Task ExecuteAsync(
        string path,
        string name,
        CancellationToken cancellationToken = default);
}
