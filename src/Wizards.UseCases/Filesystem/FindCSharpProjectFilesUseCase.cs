namespace Wizards.UseCases.Filesystem;

public class FindCSharpProjectFilesUseCase : IFindCSharpProjectFilesUseCase
{
    public Task<IEnumerable<string>> ExecuteAsync(
        string directory,
        CancellationToken cancellationToken)
    {
        var files = Directory.GetFiles(
            path: directory,
            searchPattern: "*.csproj",
            SearchOption.AllDirectories);

        return Task.FromResult<IEnumerable<string>>(files);
    }
}
