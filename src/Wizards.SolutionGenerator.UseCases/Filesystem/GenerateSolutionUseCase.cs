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
        string directory,
        string name,
        CancellationToken cancellationToken = default)
    {
        //
        //
        //
        #region Generate solution from makefile.

        #endregion

        //
        //
        //
        #region Generate solution from directory.

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
            name: name,
            cancellationToken);

        foreach (var file in filesRelative)
        {
            await _dotNetSolutionAddCommand.ExecuteAsync(
                directory: directory,
                name: name,
                reference: file,
                cancellationToken);
        }

        #endregion
    }
}
