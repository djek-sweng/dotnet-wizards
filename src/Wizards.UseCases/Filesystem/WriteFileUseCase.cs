namespace Wizards.UseCases.Filesystem;

public class WriteFileUseCase : IWriteFileUseCase
{
    public async Task ExecuteAsync(
        string path,
        string content,
        CancellationToken cancellationToken = default)
    {
        await using var writer = new StreamWriter(path, append: false);

        await writer.WriteLineAsync(content);
    }
}
