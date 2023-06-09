namespace Wizards.Commands.DotNet;

public class DotNetInfoCommand : IDotNetInfoCommand
{
    private readonly IRunShellCommandUseCase _runShellCommandUseCase;

    public DotNetInfoCommand(
        IRunShellCommandUseCase runShellCommandUseCase)
    {
        _runShellCommandUseCase = runShellCommandUseCase;
    }

    public async Task<string> ExecuteAsync(
        string directory,
        CancellationToken cancellationToken = default)
    {
        return await _runShellCommandUseCase.ExecuteAsync(
            command: $@"cd ""{directory}""; dotnet --info;",
            cancellationToken);
    }
}
