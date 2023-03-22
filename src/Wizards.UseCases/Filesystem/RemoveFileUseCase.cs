namespace Wizards.UseCases.Filesystem;

public class RemoveFileUseCase : IRemoveFileUseCase
{
    public Task ExecuteAsync(
        string directory,
        string name,
        CancellationToken cancellationToken = default)
    {
        var path = Path.Combine(directory, name);

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        return Task.CompletedTask;
    }
}
