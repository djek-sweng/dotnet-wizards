namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public class GenerateSolutionFromDirectoryUseCase : IGenerateSolutionFromDirectoryUseCase
{
    private readonly IFindCSharpProjectFilesUseCase _findCSharpProjectFilesUseCase;
    private readonly IRemoveStringStartsWithUseCase _removeStringStartsWithUseCase;
    private readonly IDotNetInfoCommand _dotNetInfoCommand;
    private readonly IDotNetNewSolutionCommand _dotNetNewSolutionCommand;
    private readonly IDotNetSolutionAddCommand _dotNetSolutionAddCommand;

    public GenerateSolutionFromDirectoryUseCase(
        IFindCSharpProjectFilesUseCase findCSharpProjectFilesUseCase,
        IRemoveStringStartsWithUseCase removeStringStartsWithUseCase,
        IDotNetInfoCommand dotNetInfoCommand,
        IDotNetNewSolutionCommand dotNetNewSolutionCommand,
        IDotNetSolutionAddCommand dotNetSolutionAddCommand)
    {
        _findCSharpProjectFilesUseCase = findCSharpProjectFilesUseCase;
        _removeStringStartsWithUseCase = removeStringStartsWithUseCase;
        _dotNetInfoCommand = dotNetInfoCommand;
        _dotNetNewSolutionCommand = dotNetNewSolutionCommand;
        _dotNetSolutionAddCommand = dotNetSolutionAddCommand;
    }

    public async Task ExecuteAsync(
        string directory,
        string solutionName,
        CancellationToken cancellationToken = default)
    {
        var filesFull = await _findCSharpProjectFilesUseCase.ExecuteAsync(
            directory: directory,
            cancellationToken);

        var startsWith = directory;

        var filesRelative = await _removeStringStartsWithUseCase.ExecuteAsync(
            fulls: filesFull,
            startsWith: startsWith,
            cancellationToken);

        await _dotNetInfoCommand.ExecuteAsync(
            directory: directory,
            cancellationToken);

        await _dotNetNewSolutionCommand.ExecuteAsync(
            directory: directory,
            name: solutionName,
            cancellationToken);

        foreach (var file in filesRelative)
        {
            await _dotNetSolutionAddCommand.ExecuteAsync(
                directory: directory,
                name: solutionName,
                reference: file,
                solutionFolder: null,
                cancellationToken);
        }
    }
}
