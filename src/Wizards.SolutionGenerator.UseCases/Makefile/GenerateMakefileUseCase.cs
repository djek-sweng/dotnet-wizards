namespace Wizards.SolutionGenerator.UseCases.Makefile;

public class GenerateMakefileUseCase : IGenerateMakefileUseCase
{
    private readonly IFindCSharpProjectFilesUseCase _findCSharpProjectFilesUseCase;
    private readonly IGenerateMakefileStringUseCase _generateMakefileStringUseCase;
    private readonly IWriteFileUseCase _writeFileUseCase;

    public GenerateMakefileUseCase(
        IFindCSharpProjectFilesUseCase findCSharpProjectFilesUseCase,
        IGenerateMakefileStringUseCase generateMakefileStringUseCase,
        IWriteFileUseCase writeFileUseCase)
    {
        _findCSharpProjectFilesUseCase = findCSharpProjectFilesUseCase;
        _generateMakefileStringUseCase = generateMakefileStringUseCase;
        _writeFileUseCase = writeFileUseCase;
    }

    public async Task ExecuteAsync(
        string directory,
        string makefileName,
        CancellationToken cancellationToken = default)
    {
        var projectFiles = await _findCSharpProjectFilesUseCase.ExecuteAsync(
            directory: directory,
            cancellationToken);

        var makefileString = await _generateMakefileStringUseCase.ExecuteAsync(
            directory: directory,
            projectFiles: projectFiles,
            cancellationToken);

        var makefilePath = MakefileHelper.GetFullName(directory, makefileName);

        await _writeFileUseCase.ExecuteAsync(
            path: makefilePath,
            content: makefileString,
            cancellationToken);
    }
}
