namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public class GenerateSolutionFromMakefileUseCase : IGenerateSolutionFromMakefileUseCase
{
    private readonly IReadFileUseCase _readFileUseCase;
    private readonly IGenerateMakefileModelUseCase _generateMakefileModelUseCase;
    private readonly IDotNetInfoCommand _dotNetInfoCommand;
    private readonly IDotNetNewSolutionCommand _dotNetNewSolutionCommand;
    private readonly IDotNetSolutionAddCommand _dotNetSolutionAddCommand;

    public GenerateSolutionFromMakefileUseCase(
        IReadFileUseCase readFileUseCase,
        IGenerateMakefileModelUseCase generateMakefileModelUseCase,
        IDotNetInfoCommand dotNetInfoCommand,
        IDotNetNewSolutionCommand dotNetNewSolutionCommand,
        IDotNetSolutionAddCommand dotNetSolutionAddCommand)
    {
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
        var makefileString = await _readFileUseCase.ExecuteAsync(
            path: makefilePath,
            cancellationToken);

        var makefileModel = await _generateMakefileModelUseCase.ExecuteAsync(
            makefileString,
            cancellationToken);

        var directory = makefileModel.RootDirectory;

        await _dotNetInfoCommand.ExecuteAsync(
            directory: directory,
            cancellationToken);

        await _dotNetNewSolutionCommand.ExecuteAsync(
            directory: directory,
            name: solutionName,
            cancellationToken);

        foreach (var project in makefileModel.Projects)
        {
            await _dotNetSolutionAddCommand.ExecuteAsync(
                directory: directory,
                name: solutionName,
                reference: project.RelativePath,
                solutionFolder: project.SolutionFolder,
                cancellationToken);
        }
    }
}
