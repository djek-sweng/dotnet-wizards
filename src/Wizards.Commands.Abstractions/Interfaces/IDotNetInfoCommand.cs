namespace Wizards.Commands.Abstractions;

public interface IDotNetInfoCommand
{
    Task<string> ExecuteAsync(
        string directory,
        CancellationToken cancellationToken = default);
}
