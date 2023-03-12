namespace Wizards.UseCases.Abstractions;

public interface IFindCsharpProjectFilesUseCase
{
    Task<string[]> ExecuteAsync(string path,
        CancellationToken cancellationToken = default);
}
