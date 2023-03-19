namespace Wizards.UseCases.Filesystem;

public class GetCurrentDirectoryUseCase : IGetCurrentDirectoryUseCase
{
    public Task<string> Execute(CancellationToken cancellationToken = default)
    {
        var directory = Environment.CurrentDirectory;

        return Task.FromResult(directory);
    }
}
