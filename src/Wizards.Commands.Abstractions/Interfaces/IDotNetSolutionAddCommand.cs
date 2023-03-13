namespace Wizards.Commands.DotNet;

public interface IDotNetSolutionAddCommand
{
    public Task ExecuteAsync(
        string directory,
        string name,
        string reference,
        CancellationToken cancellationToken = default);
}
