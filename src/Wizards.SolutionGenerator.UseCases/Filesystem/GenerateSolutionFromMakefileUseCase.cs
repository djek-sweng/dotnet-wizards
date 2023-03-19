namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public class GenerateSolutionFromMakefileUseCase : IGenerateSolutionFromMakefileUseCase
{
    private readonly IGetCurrentDirectoryUseCase _getCurrentDirectoryUseCase;
    private readonly IGetFileInfoUseCase _getFileInfoUseCase;
    private readonly IJumpToDirectoryUseCase _jumpToDirectoryUseCase;
    private readonly IReadFileUseCase _readFileUseCase;
    private readonly IGenerateMakefileModelUseCase _generateMakefileModelUseCase;
    private readonly IDotNetInfoCommand _dotNetInfoCommand;
    private readonly IDotNetNewSolutionCommand _dotNetNewSolutionCommand;
    private readonly IDotNetSolutionAddCommand _dotNetSolutionAddCommand;

    public GenerateSolutionFromMakefileUseCase(
        IGetCurrentDirectoryUseCase getCurrentDirectoryUseCase,
        IGetFileInfoUseCase getFileInfoUseCase,
        IJumpToDirectoryUseCase jumpToDirectoryUseCase,
        IReadFileUseCase readFileUseCase,
        IGenerateMakefileModelUseCase generateMakefileModelUseCase,
        IDotNetInfoCommand dotNetInfoCommand,
        IDotNetNewSolutionCommand dotNetNewSolutionCommand,
        IDotNetSolutionAddCommand dotNetSolutionAddCommand)
    {
        _getCurrentDirectoryUseCase = getCurrentDirectoryUseCase;
        _getFileInfoUseCase = getFileInfoUseCase;
        _jumpToDirectoryUseCase = jumpToDirectoryUseCase;
        _readFileUseCase = readFileUseCase;
        _generateMakefileModelUseCase = generateMakefileModelUseCase;
        _dotNetInfoCommand = dotNetInfoCommand;
        _dotNetNewSolutionCommand = dotNetNewSolutionCommand;
        _dotNetSolutionAddCommand = dotNetSolutionAddCommand;
    }

    public async Task ExecuteAsync(
        string makefilePath,
        string solutionName,
        CancellationToken cancellationToken = default)
    {
        var workingDirectory = await _getCurrentDirectoryUseCase.Execute(cancellationToken);

        var makefileInfo = await _getFileInfoUseCase.Execute(
            file: makefilePath,
            cancellationToken);

        var makefileDirectory = makefileInfo.Directory;

        await _jumpToDirectoryUseCase.Execute(
            directory: makefileDirectory,
            cancellationToken);

        var makefileString = await _readFileUseCase.ExecuteAsync(
            path: makefilePath,
            cancellationToken);

        var makefileModel = await _generateMakefileModelUseCase.ExecuteAsync(
            makefileString,
            cancellationToken);

        await _dotNetInfoCommand.ExecuteAsync(
            directory: makefileDirectory,
            cancellationToken);

        await _dotNetNewSolutionCommand.ExecuteAsync(
            directory: makefileDirectory,
            name: solutionName,
            cancellationToken);

        foreach (var project in makefileModel.Projects)
        {
            await _dotNetSolutionAddCommand.ExecuteAsync(
                directory: makefileDirectory,
                name: solutionName,
                reference: project.RelativePath,
                solutionFolder: project.SolutionFolder,
                cancellationToken);
        }

        // todo: jump back to "workingDirectory"
    }
}
