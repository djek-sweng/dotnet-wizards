namespace Wizards.Commands.DotNet;

public class DotNetNewSolutionCommand : IDotNetNewSolutionCommand
{
    private readonly IRemoveFileUseCase _removeFileUseCase;
    private readonly IRunShellCommandUseCase _runShellCommandUseCase;

    public DotNetNewSolutionCommand(
        IRemoveFileUseCase removeFileUseCase,
        IRunShellCommandUseCase runShellCommandUseCase)
    {
        _removeFileUseCase = removeFileUseCase;
        _runShellCommandUseCase = runShellCommandUseCase;
    }

    public async Task ExecuteAsync(
        string directory,
        string name,
        CancellationToken cancellationToken = default)
    {
        var fileName = name + SolutionHelper.FileExtension;

        await _removeFileUseCase.ExecuteAsync(
            directory: directory,
            name: fileName,
            cancellationToken);

        await _runShellCommandUseCase.ExecuteAsync(
            command: $@"cd ""{directory}""; dotnet new ""sln"" -n ""{name}"";",
            cancellationToken);
    }
}
