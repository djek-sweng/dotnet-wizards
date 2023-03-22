namespace Wizards.SolutionGenerator.UseCases.Solution;

public class GenerateSolutionFromMakefileUseCase : IGenerateSolutionFromMakefileUseCase
{
    private readonly IGetCurrentDirectoryUseCase _getCurrentDirectoryUseCase;
    private readonly IEnsureFileExistsUseCase _ensureFileExistsUseCase;
    private readonly IJumpToDirectoryUseCase _jumpToDirectoryUseCase;
    private readonly IReadFileUseCase _readFileUseCase;
    private readonly IGenerateMakefileModelUseCase _generateMakefileModelUseCase;
    private readonly IDotNetNewSolutionCommand _dotNetNewSolutionCommand;
    private readonly IDotNetSolutionAddCommand _dotNetSolutionAddCommand;

    public GenerateSolutionFromMakefileUseCase(
        IGetCurrentDirectoryUseCase getCurrentDirectoryUseCase,
        IEnsureFileExistsUseCase ensureFileExistsUseCase,
        IJumpToDirectoryUseCase jumpToDirectoryUseCase,
        IReadFileUseCase readFileUseCase,
        IGenerateMakefileModelUseCase generateMakefileModelUseCase,
        IDotNetNewSolutionCommand dotNetNewSolutionCommand,
        IDotNetSolutionAddCommand dotNetSolutionAddCommand)
    {
        _getCurrentDirectoryUseCase = getCurrentDirectoryUseCase;
        _ensureFileExistsUseCase = ensureFileExistsUseCase;
        _jumpToDirectoryUseCase = jumpToDirectoryUseCase;
        _readFileUseCase = readFileUseCase;
        _generateMakefileModelUseCase = generateMakefileModelUseCase;
        _dotNetNewSolutionCommand = dotNetNewSolutionCommand;
        _dotNetSolutionAddCommand = dotNetSolutionAddCommand;
    }

    public async Task ExecuteAsync(
        string makefilePath,
        string solutionName,
        CancellationToken cancellationToken = default)
    {
        var workingDirectory = await _getCurrentDirectoryUseCase.Execute(
            cancellationToken);

        var makefileInfo = await _ensureFileExistsUseCase.ExecuteAsync(
            filePath: makefilePath,
            cancellationToken);

        var makefileDirectory = makefileInfo.Directory;
        var makefileName = makefileInfo.Name;

        await _jumpToDirectoryUseCase.Execute(
            directory: makefileDirectory,
            cancellationToken);

        var makefileString = await _readFileUseCase.ExecuteAsync(
            path: makefileName,
            cancellationToken);

        var makefileModel = await _generateMakefileModelUseCase.ExecuteAsync(
            makefileString,
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
                reference: project.Reference,
                solutionFolder: project.SolutionFolder,
                cancellationToken);
        }

        await _jumpToDirectoryUseCase.Execute(
            directory: workingDirectory,
            cancellationToken);
    }
}
