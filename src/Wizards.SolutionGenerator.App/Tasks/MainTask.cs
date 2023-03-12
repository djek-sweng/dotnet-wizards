namespace Wizards.SolutionGenerator.App.Tasks;

public class MainTask : IMainTask
{
    private readonly IGenerateMakefileUseCase _generateMakefileUseCase;
    private readonly IGenerateSolutionUseCase _generateSolutionUseCase;

    public MainTask(
        IGenerateMakefileUseCase generateMakefileUseCase,
        IGenerateSolutionUseCase generateSolutionUseCase)
    {
        _generateMakefileUseCase = generateMakefileUseCase;
        _generateSolutionUseCase = generateSolutionUseCase;
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
        var path = options.Path;

        await _generateMakefileUseCase.ExecuteAsync(path);

        // todo: Move to settings.
        var filePath = path + Path.DirectorySeparatorChar + "makefile.json";

        await _generateSolutionUseCase.ExecuteAsync(path: /*filePath*/ path);
    }

    private Task HandleParseError(IEnumerable<Error> errors)
    {
        // Handle errors.

        return Task.CompletedTask;
    }
}
