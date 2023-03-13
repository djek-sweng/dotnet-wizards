namespace Wizards.Commands.DotNet;

public class DotNetNewSolutionCommand : IDotNetNewSolutionCommand
{
    private readonly IRunShellCommandUseCase _runShellCommandUseCase;

    public DotNetNewSolutionCommand(
        IRunShellCommandUseCase runShellCommandUseCase)
    {
        _runShellCommandUseCase = runShellCommandUseCase;
    }

    public async Task ExecuteAsync(
        string directory,
        string name,
        CancellationToken cancellationToken = default)
    {
        await _runShellCommandUseCase.ExecuteAsync(
            command: $@"cd ""{directory}""; dotnet new ""sln"" -n ""{name}"";",
            cancellationToken);
    }
}
