namespace Wizards.UseCases.Filesystem;

public class FindCSharpProjectFilesUseCase : IFindCsharpProjectFilesUseCase
{
    public Task<string[]> ExecuteAsync(string path,
        CancellationToken cancellationToken)
    {
        var files = Directory.GetFiles(
            path,
            searchPattern: "*.csproj",
            SearchOption.AllDirectories);

        return Task.FromResult(files);
    }
}
