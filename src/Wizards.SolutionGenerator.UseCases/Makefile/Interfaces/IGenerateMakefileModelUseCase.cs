namespace Wizards.SolutionGenerator.UseCases.Makefile;

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
