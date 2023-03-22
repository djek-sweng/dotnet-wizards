namespace Wizards.SolutionGenerator.UseCases.Makefile;

public interface IGenerateMakefileStringUseCase
{
    Task<string> ExecuteAsync(
        string directory,
        IEnumerable<string> projectFiles,
        CancellationToken cancellationToken = default);
}
