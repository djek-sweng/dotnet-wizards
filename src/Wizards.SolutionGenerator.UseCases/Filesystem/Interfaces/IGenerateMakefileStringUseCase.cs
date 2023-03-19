namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public interface IGenerateMakefileStringUseCase
{
    Task<string> ExecuteAsync(
        string directory,
        IEnumerable<string> projectFiles,
        CancellationToken cancellationToken = default);
}
