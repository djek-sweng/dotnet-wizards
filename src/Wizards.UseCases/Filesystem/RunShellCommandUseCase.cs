namespace Wizards.UseCases.Filesystem;

public class RunShellCommandUseCase : IRunShellCommandUseCase
{
    private readonly ILogger<RunShellCommandUseCase> _logger;

    public RunShellCommandUseCase(
        ILogger<RunShellCommandUseCase> logger)
    {
        _logger = logger;
    }

    public Task ExecuteAsync(
        string command,
        CancellationToken cancellationToken = default)
    {
        var process = RunProcess(command);

        LogProcess(process);

        return Task.CompletedTask;
    }

    private static Process RunProcess(string command)
    {
        var process = new Process();

        process.StartInfo.FileName = "/bin/sh";
        process.StartInfo.Arguments = "-c \"" + command + "\"";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();

        return process;
    }

    private void LogProcess(Process process)
    {
        var stringBuilder = new StringBuilder();

        while (!process.StandardOutput.EndOfStream)
        {
            stringBuilder.AppendLine(process.StandardOutput.ReadLine());
        }

        var message = stringBuilder.ToString();

        if (!string.IsNullOrEmpty(message))
        {
            _logger.LogInformation("{Message}", message);
        }
    }
}
