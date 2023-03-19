namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public class GenerateMakefileModelUseCase : IGenerateMakefileModelUseCase
{
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
            RootDirectory = directory,
            Projects = cSharpProjectModels
        };

        return Task.FromResult(makefileModel);
    }

    public Task<MakefileModel> ExecuteAsync(
        string makefileString,
        CancellationToken cancellationToken = default)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };

        var makefileModel = JsonSerializer.Deserialize<MakefileModel>(makefileString, options);

        if (makefileModel == null)
        {
            throw new NullReferenceException();
        }

        return Task.FromResult(makefileModel);
    }
}