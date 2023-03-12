namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public class GenerateSolutionUseCase : IGenerateSolutionUseCase
{
    private readonly IRunShellCommandUseCase _runShellCommandUseCase;
    private readonly IFindCSharpProjectFilesUseCase _findCSharpProjectFilesUseCase;
    private readonly IRemoveStringStartsWithUseCase _removeStringStartsWithUseCase;

    public GenerateSolutionUseCase(
        IRunShellCommandUseCase runShellCommandUseCase,
        IFindCSharpProjectFilesUseCase findCSharpProjectFilesUseCase,
        IRemoveStringStartsWithUseCase removeStringStartsWithUseCase)
    {
        _runShellCommandUseCase = runShellCommandUseCase;
        _findCSharpProjectFilesUseCase = findCSharpProjectFilesUseCase;
        _removeStringStartsWithUseCase = removeStringStartsWithUseCase;
    }

    public async Task ExecuteAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        await _runShellCommandUseCase.ExecuteAsync(
            "dotnet --info",
            cancellationToken);

        #region Test Code here.

        var currentDirectory = Directory.GetCurrentDirectory();

        var solutionName = /*path */ "MySolution";

        await _runShellCommandUseCase.ExecuteAsync(
            $@"cd ""{path}""; rm -rf ""{solutionName}.sln""",
            cancellationToken);

        await _runShellCommandUseCase.ExecuteAsync(
            $@"cd ""{path}""; dotnet new ""sln"" -n ""{solutionName}""",
            cancellationToken);

        var filesFull = await _findCSharpProjectFilesUseCase.ExecuteAsync(
            path,
            cancellationToken);

        var filesRelative = await _removeStringStartsWithUseCase.ExecuteAsync(
            filesFull,
            path,
            cancellationToken);

        foreach (var file in filesRelative)
        {
            //dotnet sln "Wizards.sln" add "Wizards.UseCases"

            await _runShellCommandUseCase.ExecuteAsync(
                $@"cd ""{path}""; dotnet sln ""{solutionName}.sln"" add ""{file}"";",
                cancellationToken);
        }

        #endregion
    }
}
