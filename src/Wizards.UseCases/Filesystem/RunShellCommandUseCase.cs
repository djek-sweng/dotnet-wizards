namespace Wizards.UseCases.Filesystem;

public class RunShellCommandUseCase : IRunShellCommandUseCase
{
    private readonly ILogger<RunShellCommandUseCase> _logger;

    public RunShellCommandUseCase(
        ILogger<RunShellCommandUseCase> logger)
    {
        _logger = logger;
    }

    public Task<string> ExecuteAsync(
        string command,
        CancellationToken cancellationToken = default)
    {
        var process = RunProcess(command);

        var message = LogProcess(process);

        return Task.FromResult(message);
    }

    private static Process RunProcess(string command)
    {
        var process = new Process();

        process.StartInfo.FileName = ShellHelper.FilePath;
        process.StartInfo.Arguments = "-c \"" + command + "\"";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();

        return process;
    }

    private string LogProcess(Process process)
    {
        var stringBuilder = new StringBuilder();

        while (false == process.StandardOutput.EndOfStream)
        {
            stringBuilder.AppendLine(process.StandardOutput.ReadLine());
        }

        var message = stringBuilder.ToString();

        if (false == string.IsNullOrEmpty(message))
        {
            _logger.LogInformation("{Message}", message);
        }

        return message;
    }
}
