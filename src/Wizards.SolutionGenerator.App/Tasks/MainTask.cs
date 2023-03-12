namespace Wizards.SolutionGenerator.App.Tasks;

public class MainTask : IMainTask
{
    private readonly IGenerateMakefileUseCase _generateMakefileUseCase;

    public MainTask(
        IGenerateMakefileUseCase generateMakefileUseCase)
    {
        _generateMakefileUseCase = generateMakefileUseCase;
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
    }

    private Task HandleParseError(IEnumerable<Error> errors)
    {
        // Handle errors.

        return Task.CompletedTask;
    }
}
