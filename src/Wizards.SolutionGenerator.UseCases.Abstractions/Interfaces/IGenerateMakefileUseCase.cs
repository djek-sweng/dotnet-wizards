namespace Wizards.SolutionGenerator.UseCases.Abstractions;

public interface IGenerateMakefileUseCase
{
    Task ExecuteAsync(
        string path,
        CancellationToken cancellationToken = default);
}
