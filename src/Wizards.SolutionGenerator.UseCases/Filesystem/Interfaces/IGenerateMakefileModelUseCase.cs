namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public interface IGenerateMakefileModelUseCase
{
    Task<MakefileModel> ExecuteAsync(
        string directory,
        IEnumerable<string> projectFiles,
        CancellationToken cancellationToken = default);

    Task<MakefileModel> ExecuteAsync(
        string makefileString,
        CancellationToken cancellationToken = default);
}
