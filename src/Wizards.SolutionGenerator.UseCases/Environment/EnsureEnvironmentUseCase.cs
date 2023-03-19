namespace Wizards.SolutionGenerator.UseCases.Environment;

public class EnsureEnvironmentUseCase : IEnsureEnvironmentUseCase
{
    private readonly IGetFileInfoUseCase _getFileInfoUseCase;
    private readonly IDotNetInfoCommand _dotNetInfoCommand;

    public EnsureEnvironmentUseCase(
        IGetFileInfoUseCase getFileInfoUseCase,
        IDotNetInfoCommand dotNetInfoCommand)
    {
        _getFileInfoUseCase = getFileInfoUseCase;
        _dotNetInfoCommand = dotNetInfoCommand;
    }

    private const string ShellFilePath = "/bin/sh";

    public async Task ExecuteAsync(
        CancellationToken cancellationToken = default)
    {
        var shellFileInfo = await _getFileInfoUseCase.Execute(
            filePath: ShellFilePath,
            cancellationToken);

        if (false == shellFileInfo.Exists)
        {
            throw new FileNotFoundException();
        }

        var message = await _dotNetInfoCommand.ExecuteAsync(
            directory: System.Environment.SystemDirectory,
            cancellationToken);

        if (false == message.Contains("Runtime Environment:"))
        {
            throw new FileNotFoundException();
        }
    }
}
