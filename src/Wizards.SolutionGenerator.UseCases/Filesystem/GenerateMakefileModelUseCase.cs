namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public class GenerateMakefileModelUseCase : IGenerateMakefileModelUseCase
{
    private readonly IAppendDirectorySeparatorCharUseCase _appendDirectorySeparatorCharUseCase;
    private readonly IRemoveStartsWithStringUseCase _removeStartsWithStringUseCase;
    private readonly IDeserializeJsonUseCase _deserializeJsonUseCase;

    public GenerateMakefileModelUseCase(
        IAppendDirectorySeparatorCharUseCase appendDirectorySeparatorCharUseCase,
        IRemoveStartsWithStringUseCase removeStartsWithStringUseCase,
        IDeserializeJsonUseCase deserializeJsonUseCase)
    {
        _appendDirectorySeparatorCharUseCase = appendDirectorySeparatorCharUseCase;
        _removeStartsWithStringUseCase = removeStartsWithStringUseCase;
        _deserializeJsonUseCase = deserializeJsonUseCase;
    }

    public async Task<MakefileModel> ExecuteAsync(
        string directory,
        IEnumerable<string> projectFiles,
        CancellationToken cancellationToken = default)
    {
        directory = await _appendDirectorySeparatorCharUseCase.ExecuteAsync(
            directory: directory,
            cancellationToken);

        var filesRelative = await _removeStartsWithStringUseCase.ExecuteAsync(
            fulls: projectFiles,
            startsWith: directory,
            cancellationToken);

        var cSharpProjectModels = filesRelative
            .Select(fileRelative =>
                new CSharpProjectModel
                {
                    SolutionFolder = string.Empty,
                    RelativePath = fileRelative
                })
            .ToList();

        var makefileModel = new MakefileModel
        {
            Projects = cSharpProjectModels
        };

        return makefileModel;
    }

    public async Task<MakefileModel> ExecuteAsync(
        string makefileString,
        CancellationToken cancellationToken = default)
    {
        var makefileModel = await _deserializeJsonUseCase.ExecuteAsync<MakefileModel>(
            jsonString: makefileString,
            cancellationToken);

        if (makefileModel == null)
        {
            throw new NullReferenceException();
        }

        return makefileModel;
    }
}
