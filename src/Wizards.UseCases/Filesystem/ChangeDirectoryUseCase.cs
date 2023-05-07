namespace Wizards.UseCases.Filesystem;

public class ChangeDirectoryUseCase : IChangeDirectoryUseCase
{
    public Task Execute(
        string directory,
        CancellationToken cancellationToken = default)
    {
        Environment.CurrentDirectory = directory;

        return Task.CompletedTask;
    }
}
