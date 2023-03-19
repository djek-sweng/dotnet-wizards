namespace Wizards.UseCases.Abstractions;

public interface IRunShellCommandUseCase
{
    Task<string> ExecuteAsync(
        string command,
        CancellationToken cancellationToken = default);
}
