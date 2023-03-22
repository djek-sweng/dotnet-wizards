namespace Wizards.UseCases.Abstractions;

public interface IFindCSharpProjectFilesUseCase
{
    Task<IEnumerable<string>> ExecuteAsync(
        string directory,
        CancellationToken cancellationToken = default);
}
