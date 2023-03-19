namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public class GenerateMakefileModelUseCase : IGenerateMakefileModelUseCase
{
    private readonly IDeserializeJsonUseCase _deserializeJsonUseCase;

    public GenerateMakefileModelUseCase(
        IDeserializeJsonUseCase deserializeJsonUseCase)
    {
        _deserializeJsonUseCase = deserializeJsonUseCase;
    }

    public Task<MakefileModel> ExecuteAsync(
        string directory,
        IEnumerable<string> filesRelative,
        CancellationToken cancellationToken = default)
    {
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

        return Task.FromResult(makefileModel);
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
