namespace Wizards.Commands.Abstractions;

public interface IDotNetInfoCommand
{
    Task ExecuteAsync(
        string directory,
        CancellationToken cancellationToken = default);
}
