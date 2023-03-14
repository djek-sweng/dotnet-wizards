namespace Wizards.SolutionGenerator.App.Options;

public class CommandLineOptions
{
    [Option("generate-makefile", Required = false, HelpText = "GenerateMakefile")]
    public bool GenerateMakefile { get; set; } = false;

    [Option("generate-solution-from-directory", Required = false, HelpText = "GenerateSolutionFromDirectory")]
    public bool GenerateSolutionFromDirectory { get; set; } = false;

    [Option("generate-solution-from-makefile", Required = false, HelpText = "GenerateSolutionFromMakefile")]
    public bool GenerateSolutionFromMakefile { get; set; } = false;

    [Option("source", Required = false, HelpText = "Source")]
    public string Source { get; set; } = string.Empty;

    [Option("name", Required = false, HelpText = "Name")]
    public string Name { get; set; } = string.Empty;
}
