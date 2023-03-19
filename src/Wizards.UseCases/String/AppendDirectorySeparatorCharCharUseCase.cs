namespace Wizards.UseCases.String;

public class AppendDirectorySeparatorCharCharUseCase : IAppendDirectorySeparatorCharUseCase
{
    public Task<string> ExecuteAsync(
        string directory,
        CancellationToken cancellationToken = default)
    {
        var buffer = directory;

        var endChar = Path.DirectorySeparatorChar;

        if (false == buffer.EndsWith(endChar))
        {
            buffer += endChar;
        }

        return Task.FromResult(buffer);
    }
}
