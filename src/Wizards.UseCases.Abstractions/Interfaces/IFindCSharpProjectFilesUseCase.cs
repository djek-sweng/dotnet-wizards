namespace Wizards.UseCases.Abstractions;

public interface IFindCSharpProjectFilesUseCase
{
    Task<IEnumerable<string>> ExecuteAsync(
        string path,
        CancellationToken cancellationToken = default);
}
