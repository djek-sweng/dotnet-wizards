namespace Wizards.UseCases.Abstractions;

public interface IEnsureFileExistsUseCase
{
    Task<FileInfoModel> ExecuteAsync(
        string filePath,
        CancellationToken cancellationToken = default);
}
