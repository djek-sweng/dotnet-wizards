namespace Wizards.SolutionGenerator.App.Options;

public class CommandLineOptions
{
    [Option("generate-makefile", Required = false, HelpText = "GenerateMakefile")]
    public bool GenerateMakefile { get; set; } = false;

    [Option("generate-solution", Required = false, HelpText = "GenerateSolution")]
    public bool GenerateSolution { get; set; } = false;

    [Option('s', "src", Required = false, HelpText = "Source")]
    public string Source { get; set; } = string.Empty;

    [Option('n', "name", Required = false, HelpText = "Name")]
    public string Name { get; set; } = string.Empty;
}
