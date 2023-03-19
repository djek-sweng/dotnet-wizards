namespace Wizards.UseCases.Filesystem;

public class GetFileInfoUseCase : IGetFileInfoUseCase
{
    public Task<FileInfoModel> Execute(
        string filePath,
        CancellationToken cancellationToken = default)
    {
        var fileInfo = new FileInfo(filePath);

        var directoryName = fileInfo.DirectoryName;

        var fileInfoModel = new FileInfoModel
        {
            Directory = directoryName ?? string.Empty,
            FullName = fileInfo.FullName,
            Name = fileInfo.Name,
            Extension = fileInfo.Extension,
            Exists = fileInfo.Exists
        };

        return Task.FromResult(fileInfoModel);
    }
}
