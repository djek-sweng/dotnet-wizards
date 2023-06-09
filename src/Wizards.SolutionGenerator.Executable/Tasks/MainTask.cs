namespace Wizards.SolutionGenerator.Executable.Tasks;

public class MainTask : IMainTask
{
    private readonly IEnsureEnvironmentUseCase _ensureEnvironmentUseCase;
    private readonly IGenerateMakefileUseCase _generateMakefileUseCase;
    private readonly IGenerateSolutionFromDirectoryUseCase _generateSolutionFromDirectoryUseCase;
    private readonly IGenerateSolutionFromMakefileUseCase _generateSolutionFromMakefileUseCase;

    public MainTask(
        IEnsureEnvironmentUseCase ensureEnvironmentUseCase,
        IGenerateMakefileUseCase generateMakefileUseCase,
        IGenerateSolutionFromDirectoryUseCase generateSolutionFromDirectoryUseCase,
        IGenerateSolutionFromMakefileUseCase generateSolutionFromMakefileUseCase)
    {
        _ensureEnvironmentUseCase = ensureEnvironmentUseCase;
        _generateMakefileUseCase = generateMakefileUseCase;
        _generateSolutionFromDirectoryUseCase = generateSolutionFromDirectoryUseCase;
        _generateSolutionFromMakefileUseCase = generateSolutionFromMakefileUseCase;
    }

    public Task ExecuteAsync(
        IEnumerable<string> args,
        CancellationToken cancellationToken = default)
    {
        Parser.Default.ParseArguments<CommandLineOptions>(args)
            .WithParsedAsync(RunOptions).GetAwaiter().GetResult()
            .WithNotParsedAsync(HandleParseError).GetAwaiter().GetResult();

        return Task.CompletedTask;
    }

    private async Task RunOptions(CommandLineOptions options)
    {
        await _ensureEnvironmentUseCase.ExecuteAsync();

        // Handle options.
        if (options.GenerateMakefile)
        {
            await _generateMakefileUseCase.ExecuteAsync(
                directory: options.Source,
                makefileName: options.Name);
            return;
        }

        if (options.GenerateSolutionFromDirectory)
        {
            await _generateSolutionFromDirectoryUseCase.ExecuteAsync(
                directory: options.Source,
                solutionName: options.Name);
            return;
        }

        if (options.GenerateSolutionFromMakefile)
        {
            await _generateSolutionFromMakefileUseCase.ExecuteAsync(
                makefilePath: options.Source,
                solutionName: options.Name);
            return;
        }

        throw new NotSupportedException();
    }

    private Task HandleParseError(IEnumerable<Error> errors)
    {
        // Handle errors.

        return Task.CompletedTask;
    }
}
