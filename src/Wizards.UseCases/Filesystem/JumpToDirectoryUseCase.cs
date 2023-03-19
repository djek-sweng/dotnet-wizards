namespace Wizards.UseCases.Filesystem;

public class JumpToDirectoryUseCase : IJumpToDirectoryUseCase
{
    public Task Execute(
        string directory,
        CancellationToken cancellationToken = default)
    {
        Environment.CurrentDirectory = directory;

        return Task.CompletedTask;
    }
}
