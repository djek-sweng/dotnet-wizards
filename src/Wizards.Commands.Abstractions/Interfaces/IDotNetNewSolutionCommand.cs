namespace Wizards.Commands.Abstractions;

public interface IDotNetNewSolutionCommand
{
    public Task ExecuteAsync(
        string directory,
        string name,
        CancellationToken cancellationToken = default);
}
