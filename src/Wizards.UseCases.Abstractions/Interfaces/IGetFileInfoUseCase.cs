namespace Wizards.UseCases.Abstractions;

public interface IGetFileInfoUseCase
{
    Task<FileInfo> Execute(
        string file,
        CancellationToken cancellationToken = default);
}
