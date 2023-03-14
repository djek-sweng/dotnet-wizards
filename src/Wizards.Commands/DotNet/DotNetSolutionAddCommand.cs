namespace Wizards.Commands.DotNet;

public class DotNetSolutionAddCommand : IDotNetSolutionAddCommand
{
    private readonly IRunShellCommandUseCase _runShellCommandUseCase;

    public DotNetSolutionAddCommand(
        IRunShellCommandUseCase runShellCommandUseCase)
    {
        _runShellCommandUseCase = runShellCommandUseCase;
    }

    public async Task ExecuteAsync(
        string directory,
        string name,
        string reference,
        string? solutionFolder = null,
        CancellationToken cancellationToken = default)
    {
        var command = string.IsNullOrWhiteSpace(solutionFolder)
            ? $@"cd ""{directory}""; dotnet sln ""{name}.sln"" add ""{reference}"";"
            : $@"cd ""{directory}""; dotnet sln ""{name}.sln"" add ""{reference}"" --solution-folder ""{solutionFolder}"";";

        await _runShellCommandUseCase.ExecuteAsync(
            command,
            cancellationToken);
    }
}
