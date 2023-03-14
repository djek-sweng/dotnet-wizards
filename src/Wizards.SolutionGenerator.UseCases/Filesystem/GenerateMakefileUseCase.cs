namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public class GenerateMakefileUseCase : IGenerateMakefileUseCase
{
    public const string MakefileExtension = ".sln_mk.json";

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

    public async Task ExecuteAsync(
        string directory,
        string name,
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

        var makefilePath = directory + Path.DirectorySeparatorChar + name + MakefileExtension;

        await _writeFileUseCase.ExecuteAsync(
            path: makefilePath,
            content: makefileString,
            cancellationToken);
    }
}
