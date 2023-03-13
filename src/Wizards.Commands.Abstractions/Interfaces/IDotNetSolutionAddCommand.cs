namespace Wizards.Commands.Abstractions;

public interface IDotNetSolutionAddCommand
{
    Task ExecuteAsync(
        string directory,
        string name,
        string reference,
        CancellationToken cancellationToken = default);
}
