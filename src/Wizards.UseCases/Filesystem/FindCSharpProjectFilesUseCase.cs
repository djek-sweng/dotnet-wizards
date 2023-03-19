namespace Wizards.UseCases.Filesystem;

public class FindCSharpProjectFilesUseCase : IFindCSharpProjectFilesUseCase
{
    public Task<IEnumerable<string>> ExecuteAsync(
        string directory,
        CancellationToken cancellationToken)
    {
        var files = Directory.GetFiles(
            path: directory,
            searchPattern: CSharpProjectHelper.FileSearchPattern,
            SearchOption.AllDirectories);

        var orderedFiles = files.Order();

        return Task.FromResult<IEnumerable<string>>(orderedFiles);
    }
}
