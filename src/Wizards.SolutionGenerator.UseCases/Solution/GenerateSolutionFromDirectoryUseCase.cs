namespace Wizards.SolutionGenerator.UseCases.Solution;

public class GenerateSolutionFromDirectoryUseCase : IGenerateSolutionFromDirectoryUseCase
{
    private readonly IFindCSharpProjectFilesUseCase _findCSharpProjectFilesUseCase;
    private readonly IAppendDirectorySeparatorCharUseCase _appendDirectorySeparatorCharUseCase;
    private readonly IRemoveStartsWithStringUseCase _removeStartsWithStringUseCase;
    private readonly IDotNetNewSolutionCommand _dotNetNewSolutionCommand;
    private readonly IDotNetSolutionAddCommand _dotNetSolutionAddCommand;

    public GenerateSolutionFromDirectoryUseCase(
        IFindCSharpProjectFilesUseCase findCSharpProjectFilesUseCase,
        IAppendDirectorySeparatorCharUseCase appendDirectorySeparatorCharUseCase,
        IRemoveStartsWithStringUseCase removeStartsWithStringUseCase,
        IDotNetNewSolutionCommand dotNetNewSolutionCommand,
        IDotNetSolutionAddCommand dotNetSolutionAddCommand)
    {
        _findCSharpProjectFilesUseCase = findCSharpProjectFilesUseCase;
        _appendDirectorySeparatorCharUseCase = appendDirectorySeparatorCharUseCase;
        _removeStartsWithStringUseCase = removeStartsWithStringUseCase;
        _dotNetNewSolutionCommand = dotNetNewSolutionCommand;
        _dotNetSolutionAddCommand = dotNetSolutionAddCommand;
    }

    public async Task ExecuteAsync(
        string directory,
        string solutionName,
        CancellationToken cancellationToken = default)
    {
        directory = await _appendDirectorySeparatorCharUseCase.ExecuteAsync(
            directory: directory,
            cancellationToken);

        var projectFiles = await _findCSharpProjectFilesUseCase.ExecuteAsync(
            directory: directory,
            cancellationToken);

        var projectFilesRelative = await _removeStartsWithStringUseCase.ExecuteAsync(
            fulls: projectFiles,
            startsWith: directory,
            cancellationToken);

        await _dotNetNewSolutionCommand.ExecuteAsync(
            directory: directory,
            name: solutionName,
            cancellationToken);

        foreach (var projectFile in projectFilesRelative)
        {
            await _dotNetSolutionAddCommand.ExecuteAsync(
                directory: directory,
                name: solutionName,
                reference: projectFile,
                solutionFolder: null,
                cancellationToken);
        }
    }
}
