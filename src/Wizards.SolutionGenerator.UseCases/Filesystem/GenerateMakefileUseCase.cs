namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public class GenerateMakefileUseCase : IGenerateMakefileUseCase
{
    private readonly IFindCSharpProjectFilesUseCase _findCSharpProjectFilesUseCase;
    private readonly IRemoveStringStartsWithUseCase _removeStringStartsWithUseCase;
    private readonly IWriteFileUseCase _writeFileUseCase;

    public GenerateMakefileUseCase(
        IFindCSharpProjectFilesUseCase findCSharpProjectFilesUseCase,
        IRemoveStringStartsWithUseCase removeStringStartsWithUseCase,
        IWriteFileUseCase writeFileUseCase)
    {
        _findCSharpProjectFilesUseCase = findCSharpProjectFilesUseCase;
        _removeStringStartsWithUseCase = removeStringStartsWithUseCase;
        _writeFileUseCase = writeFileUseCase;
    }

    public async Task ExecuteAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        var filesFull = await _findCSharpProjectFilesUseCase.ExecuteAsync(
            path,
            cancellationToken);

        var filesRelative = await _removeStringStartsWithUseCase.ExecuteAsync(
            filesFull,
            path,
            cancellationToken);

        var makefileString = GenerateMakefileString(path, filesRelative);

        // todo: Move to settings.
        var filePath = path + Path.DirectorySeparatorChar + "makefile.json";

        await _writeFileUseCase.ExecuteAsync(
            path: filePath,
            content: makefileString,
            cancellationToken);
    }

    private static string GenerateMakefileString(
        string path,
        IEnumerable<string> filesRelative)
    {
        var makefileObject = GenerateMakefileObject(path, filesRelative);

        var options = new JsonSerializerOptions { WriteIndented = true };

        return JsonSerializer.Serialize(makefileObject, options);
    }

    private static MakefileObject GenerateMakefileObject(
        string path,
        IEnumerable<string> filesRelative)
    {
        var cSharpFileObjects = filesRelative
            .Select(fileRelative =>
                new CSharpFileObject
                {
                    SolutionDirectory = string.Empty,
                    RelativePath = fileRelative
                })
            .ToList();

        return new MakefileObject
        {
            RootPath = path,
            ProjectFiles = cSharpFileObjects
        };
    }
}

internal class MakefileObject
{
    public string RootPath { get; set; } = string.Empty;
    public IEnumerable<CSharpFileObject> ProjectFiles { get; set; } = ArraySegment<CSharpFileObject>.Empty;
}

internal class CSharpFileObject
{
    public string SolutionDirectory { get; set; } = string.Empty;
    public string RelativePath { get; set; } = string.Empty;
}
