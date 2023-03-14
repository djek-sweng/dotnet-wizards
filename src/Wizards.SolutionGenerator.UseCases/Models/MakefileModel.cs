namespace Wizards.SolutionGenerator.UseCases.Models;

public class MakefileModel
{
    public string RootDirectory { get; set; } = string.Empty;
    public IEnumerable<CSharpProjectModel> Projects { get; set; } = ArraySegment<CSharpProjectModel>.Empty;
}
