namespace Wizards.UseCases.Filesystem;

public class GetFileInfoUseCase : IGetFileInfoUseCase
{
    public Task<FileInfo> Execute(
        string file,
        CancellationToken cancellationToken = default)
    {
        var fileInfo = new FileInfo(file);

        return Task.FromResult(fileInfo);
    }
}
