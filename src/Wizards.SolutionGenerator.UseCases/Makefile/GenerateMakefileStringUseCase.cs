namespace Wizards.SolutionGenerator.UseCases.Makefile;

public class GenerateMakefileStringUseCase : IGenerateMakefileStringUseCase
{
    private readonly IGenerateMakefileModelUseCase _generateMakefileModelUseCase;
    private readonly ISerializeJsonUseCase _serializeJsonUseCase;

    public GenerateMakefileStringUseCase(
        IGenerateMakefileModelUseCase generateMakefileModelUseCase,
        ISerializeJsonUseCase serializeJsonUseCase)
    {
        _generateMakefileModelUseCase = generateMakefileModelUseCase;
        _serializeJsonUseCase = serializeJsonUseCase;
    }

    public async Task<string> ExecuteAsync(
        string directory,
        IEnumerable<string> projectFiles,
        CancellationToken cancellationToken = default)
    {
        var makefileModel = await _generateMakefileModelUseCase.ExecuteAsync(
            directory,
            projectFiles,
            cancellationToken);

        return await _serializeJsonUseCase.ExecuteAsync(
            jsonObject: makefileModel,
            cancellationToken);
    }
}
