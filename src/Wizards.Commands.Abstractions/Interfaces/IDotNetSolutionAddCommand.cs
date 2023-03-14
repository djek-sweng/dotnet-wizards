namespace Wizards.Commands.Abstractions;

public interface IDotNetSolutionAddCommand
{
    Task ExecuteAsync(
        string directory,
        string name,
        string reference,
        string? solutionFolder = null,
        CancellationToken cancellationToken = default);
}
