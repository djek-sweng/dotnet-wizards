namespace Wizards.SolutionGenerator.UseCases.Models;

public class MakefileModel
{
    public IEnumerable<CSharpProjectModel> Projects { get; set; } = ArraySegment<CSharpProjectModel>.Empty;
}
