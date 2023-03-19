namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public class GenerateMakefileUseCase : IGenerateMakefileUseCase
{
    private readonly IFindCSharpProjectFilesUseCase _findCSharpProjectFilesUseCase;
    private readonly IRemoveStringStartsWithUseCase _removeStringStartsWithUseCase;
    private readonly IGenerateMakefileStringUseCase _generateMakefileStringUseCase;
    private readonly IWriteFileUseCase _writeFileUseCase;

    public GenerateMakefileUseCase(
        IFindCSharpProjectFilesUseCase findCSharpProjectFilesUseCase,
        IRemoveStringStartsWithUseCase removeStringStartsWithUseCase,
        IGenerateMakefileStringUseCase generateMakefileStringUseCase,
        IWriteFileUseCase writeFileUseCase)
    {
        _findCSharpProjectFilesUseCase = findCSharpProjectFilesUseCase;
        _removeStringStartsWithUseCase = removeStringStartsWithUseCase;
        _generateMakefileStringUseCase = generateMakefileStringUseCase;
        _writeFileUseCase = writeFileUseCase;
    }

    private const string MakefileExtension = ".sln_mk.json";

    public async Task ExecuteAsync(
        string directory,
        string makefileName,
        CancellationToken cancellationToken = default)
    {
        var filesFull = await _findCSharpProjectFilesUseCase.ExecuteAsync(
            directory: directory,
            cancellationToken);

        var startsWith = directory;

        var filesRelative = await _removeStringStartsWithUseCase.ExecuteAsync(
            fulls: filesFull,
            startsWith: startsWith,
            cancellationToken);

        var makefileString = await _generateMakefileStringUseCase.ExecuteAsync(
            directory,
            filesRelative,
            cancellationToken);

        var makefilePath = directory + Path.DirectorySeparatorChar + makefileName + MakefileExtension;

        await _writeFileUseCase.ExecuteAsync(
            path: makefilePath,
            content: makefileString,
            cancellationToken);
    }
}
