namespace Wizards.UseCases.Filesystem;

public class GetFileInfoUseCase : IGetFileInfoUseCase
{
    public Task<FileInfoModel> Execute(
        string file,
        CancellationToken cancellationToken = default)
    {
        var fileInfo = new FileInfo(file);

        var directoryName = fileInfo.DirectoryName;

        if (directoryName == null)
        {
            throw new NullReferenceException(nameof(directoryName));
        }

        var fileInfoModel = new FileInfoModel
        {
            Directory = directoryName,
            FullName = fileInfo.FullName,
            Name = fileInfo.Name,
            Extension = fileInfo.Extension
        };

        return Task.FromResult(fileInfoModel);
    }
}
