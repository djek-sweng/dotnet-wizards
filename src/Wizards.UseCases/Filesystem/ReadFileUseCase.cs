namespace Wizards.UseCases.Filesystem;

public class ReadFileUseCase : IReadFileUseCase
{
    public async Task<string> ExecuteAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        using var reader = new StreamReader(path);

        return await reader.ReadToEndAsync(cancellationToken);
    }
}
