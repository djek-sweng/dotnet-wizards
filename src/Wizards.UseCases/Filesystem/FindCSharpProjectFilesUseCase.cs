namespace Wizards.UseCases.Filesystem;

public class FindCSharpProjectFilesUseCase : IFindCSharpProjectFilesUseCase
{
    public Task<IEnumerable<string>> ExecuteAsync(
        string path,
        CancellationToken cancellationToken)
    {
        var files = Directory.GetFiles(
            path,
            searchPattern: "*.csproj",
            SearchOption.AllDirectories);

        return Task.FromResult<IEnumerable<string>>(files);
    }
}
