namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public interface IGenerateMakefileStringUseCase
{
    Task<string> ExecuteAsync(
        string directory,
        IEnumerable<string> filesRelative,
        CancellationToken cancellationToken = default);
}
