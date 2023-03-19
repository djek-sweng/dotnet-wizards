namespace Wizards.UseCases.Abstractions;

public interface IGetFileInfoUseCase
{
    Task<FileInfoModel> Execute(
        string file,
        CancellationToken cancellationToken = default);
}
