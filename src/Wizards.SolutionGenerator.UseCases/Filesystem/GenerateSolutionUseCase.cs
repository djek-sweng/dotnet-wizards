namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public class GenerateSolutionUseCase : IGenerateSolutionUseCase
{
    private readonly IFindCSharpProjectFilesUseCase _findCSharpProjectFilesUseCase;
    private readonly IRemoveStringStartsWithUseCase _removeStringStartsWithUseCase;
    private readonly IDotNetInfoCommand _dotNetInfoCommand;
    private readonly IDotNetNewSolutionCommand _dotNetNewSolutionCommand;
    private readonly IDotNetSolutionAddCommand _dotNetSolutionAddCommand;

    public GenerateSolutionUseCase(
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
        string path,
        string name,
        CancellationToken cancellationToken = default)
    {
        // var currentDirectory = Directory.GetCurrentDirectory();

        #region Generate solution from directory.

        var filesFull = await _findCSharpProjectFilesUseCase.ExecuteAsync(
            path: path,
            cancellationToken);

        var filesRelative = await _removeStringStartsWithUseCase.ExecuteAsync(
            fulls: filesFull,
            startsWith: path,
            cancellationToken);

        await _dotNetInfoCommand.ExecuteAsync(
            directory: path,
            cancellationToken);

        await _dotNetNewSolutionCommand.ExecuteAsync(
            directory: path,
            name: name,
            cancellationToken);

        foreach (var file in filesRelative)
        {
            await _dotNetSolutionAddCommand.ExecuteAsync(
                directory: path,
                name: name,
                reference: file,
                cancellationToken);
        }

        #endregion
    }
}
