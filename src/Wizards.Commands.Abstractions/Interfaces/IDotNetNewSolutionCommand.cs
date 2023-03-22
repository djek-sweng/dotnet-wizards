namespace Wizards.Commands.Abstractions;

public interface IDotNetNewSolutionCommand
{
    Task ExecuteAsync(
        string directory,
        string name,
        CancellationToken cancellationToken = default);
}
