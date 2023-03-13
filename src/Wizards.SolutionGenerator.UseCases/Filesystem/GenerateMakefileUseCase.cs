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

        var makefileString = GenerateMakefileString(directory, filesRelative);

        var makefilePath = directory + Path.DirectorySeparatorChar + name + ".sln_mk.json";

        await _writeFileUseCase.ExecuteAsync(
            path: makefilePath,
            content: makefileString,
            cancellationToken);
    }

    private static string GenerateMakefileString(
        string directory,
        IEnumerable<string> filesRelative)
    {
        var makefileObject = GenerateMakefileObject(directory, filesRelative);

        var options = new JsonSerializerOptions { WriteIndented = true };

        return JsonSerializer.Serialize(makefileObject, options);
    }

    private static MakefileObject GenerateMakefileObject(
        string directory,
        IEnumerable<string> filesRelative)
    {
        var cSharpFileObjects = filesRelative
            .Select(fileRelative =>
                new CSharpFileObject
                {
                    SolutionFolder = string.Empty,
                    RelativePath = fileRelative
                })
            .ToList();

        return new MakefileObject
        {
            RootDirectory = directory,
            Projects = cSharpFileObjects
        };
    }
}

internal class MakefileObject
{
    public string RootDirectory { get; set; } = string.Empty;
    public IEnumerable<CSharpFileObject> Projects { get; set; } = ArraySegment<CSharpFileObject>.Empty;
}

internal class CSharpFileObject
{
    public string SolutionFolder { get; set; } = string.Empty;
    public string RelativePath { get; set; } = string.Empty;
}
