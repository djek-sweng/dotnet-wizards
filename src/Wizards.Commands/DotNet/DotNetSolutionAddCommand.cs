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
        CancellationToken cancellationToken = default)
    {
        // dotnet sln "Wizards.sln" add "Wizards.UseCases" --solution-folder "UseCases"
        await _runShellCommandUseCase.ExecuteAsync(
            $@"cd ""{directory}""; dotnet sln ""{name}.sln"" add ""{reference}"";",
            cancellationToken);
    }
}
