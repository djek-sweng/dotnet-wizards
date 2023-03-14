namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public class GenerateMakefileStringUseCase : IGenerateMakefileStringUseCase
{
    private readonly IGenerateMakefileModelUseCase _generateMakefileModelUseCase;

    public GenerateMakefileStringUseCase(
        IGenerateMakefileModelUseCase generateMakefileModelUseCase)
    {
        _generateMakefileModelUseCase = generateMakefileModelUseCase;
    }

    public async Task<string> ExecuteAsync(
        string directory,
        IEnumerable<string> filesRelative,
        CancellationToken cancellationToken = default)
    {
        var makefileModel = await _generateMakefileModelUseCase.ExecuteAsync(
            directory,
            filesRelative,
            cancellationToken);

        var options = new JsonSerializerOptions { WriteIndented = true };

        return JsonSerializer.Serialize(makefileModel, options);
    }
}
