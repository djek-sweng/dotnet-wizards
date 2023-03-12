namespace Wizards.UseCases.Abstractions;

public interface IRunShellCommandUseCase
{
    Task ExecuteAsync(
        string command,
        CancellationToken cancellationToken = default);
}
