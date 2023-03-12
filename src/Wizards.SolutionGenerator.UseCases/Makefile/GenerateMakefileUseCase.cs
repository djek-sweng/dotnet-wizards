namespace Wizards.SolutionGenerator.UseCases.Makefile;

public class GenerateMakefileUseCase : IGenerateMakefileUseCase
{
    private readonly IFindCSharpProjectFilesUseCase _findCSharpProjectFilesUseCase;

    public GenerateMakefileUseCase(
        IFindCSharpProjectFilesUseCase findCSharpProjectFilesUseCase)
    {
        _findCSharpProjectFilesUseCase = findCSharpProjectFilesUseCase;
    }

    public async Task ExecuteAsync(
        string path,
        CancellationToken cancellationToken = default)
    {
        var files = await _findCSharpProjectFilesUseCase.ExecuteAsync(path, cancellationToken);


    }
}
