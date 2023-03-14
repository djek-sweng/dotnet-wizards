namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public interface IGenerateMakefileModelUseCase
{
    Task<MakefileModel> ExecuteAsync(
        string directory,
        IEnumerable<string> filesRelative,
        CancellationToken cancellationToken = default);
}
