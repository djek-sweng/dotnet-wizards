namespace Wizards.SolutionGenerator.UseCases.Filesystem;

public class GenerateMakefileStringUseCase : IGenerateMakefileStringUseCase
{
    private readonly IGenerateMakefileModelUseCase _generateMakefileModelUseCase;
    private readonly IRemoveStringStartsWithUseCase _removeStringStartsWithUseCase;

    public GenerateMakefileStringUseCase(
        IGenerateMakefileModelUseCase generateMakefileModelUseCase,
        IRemoveStringStartsWithUseCase removeStringStartsWithUseCase)
    {
        _generateMakefileModelUseCase = generateMakefileModelUseCase;
        _removeStringStartsWithUseCase = removeStringStartsWithUseCase;
    }

    public async Task<string> ExecuteAsync(
        string directory,
        IEnumerable<string> projectFiles,
        CancellationToken cancellationToken = default)
    {
        //
        // todo: refactor "directory" string removing
        //
        var startsWith = directory;

        var filesRelative = await _removeStringStartsWithUseCase.ExecuteAsync(
            fulls: projectFiles,
            startsWith: startsWith,
            cancellationToken);

        var makefileModel = await _generateMakefileModelUseCase.ExecuteAsync(
            directory,
            filesRelative,
            cancellationToken);

        var options = new JsonSerializerOptions { WriteIndented = true };

        return JsonSerializer.Serialize(makefileModel, options);
    }
}
