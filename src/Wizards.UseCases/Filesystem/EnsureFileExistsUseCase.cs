namespace Wizards.UseCases.Filesystem;

public class EnsureFileExistsUseCase : IEnsureFileExistsUseCase
{
    private readonly IGetFileInfoUseCase _getFileInfoUseCase;

    public EnsureFileExistsUseCase(
        IGetFileInfoUseCase getFileInfoUseCase)
    {
        _getFileInfoUseCase = getFileInfoUseCase;
    }

    public async Task<FileInfoModel> ExecuteAsync(
        string filePath,
        CancellationToken cancellationToken = default)
    {
        var fileInfo = await _getFileInfoUseCase.Execute(
            filePath,
            cancellationToken);

        if (false == fileInfo.Exists)
        {
            throw new FileNotFoundException();
        }

        return fileInfo;
    }
}
