namespace Wizards.SolutionGenerator.UseCases.Models;

public class CSharpProjectModel
{
    public bool IsAdded { get; set; } = false;
    public string SolutionFolder { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
}
