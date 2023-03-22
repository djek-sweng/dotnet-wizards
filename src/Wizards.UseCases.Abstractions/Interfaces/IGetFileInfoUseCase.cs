namespace Wizards.UseCases.Abstractions;

public interface IGetFileInfoUseCase
{
    Task<FileInfoModel> Execute(
        string filePath,
        CancellationToken cancellationToken = default);
}
