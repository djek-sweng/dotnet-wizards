namespace Wizards.SolutionGenerator.App.Tasks;

public class MainTask : IMainTask
{
    private readonly IGenerateMakefileUseCase _generateMakefileUseCase;
    private readonly IGenerateSolutionFromDirectoryUseCase _generateSolutionFromDirectoryUseCase;
    private readonly IGenerateSolutionFromMakefileUseCase _generateSolutionFromMakefileUseCase;

    public MainTask(
        IGenerateMakefileUseCase generateMakefileUseCase,
        IGenerateSolutionFromDirectoryUseCase generateSolutionFromDirectoryUseCase,
        IGenerateSolutionFromMakefileUseCase generateSolutionFromMakefileUseCase)
    {
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
        // Handle options.
        if (options.GenerateMakefile)
        {
            await _generateMakefileUseCase.ExecuteAsync(
                directory: options.Source,
                name: options.Name);
            return;
        }

        if (options.GenerateSolutionFromDirectory)
        {
            await _generateSolutionFromDirectoryUseCase.ExecuteAsync(
                directory: options.Source,
                name: options.Name);
            return;
        }

        if (options.GenerateSolutionFromMakefile)
        {
            await _generateSolutionFromMakefileUseCase.ExecuteAsync(
                makefilePath: options.Source,
                name: options.Name);
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
