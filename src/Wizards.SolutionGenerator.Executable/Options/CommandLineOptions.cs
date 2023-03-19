namespace Wizards.SolutionGenerator.Executable.Options;

public class CommandLineOptions
{
    [Option(
        "generate-makefile",
        Required = false,
        HelpText = "Generate makefile.")]
    public bool GenerateMakefile { get; set; } = false;

    [Option(
        "generate-solution-from-directory",
        Required = false,
        HelpText = "Generate solution from directory.")]
    public bool GenerateSolutionFromDirectory { get; set; } = false;

    [Option(
        "generate-solution-from-makefile",
        Required = false,
        HelpText = "Generate solution from makefile.")]
    public bool GenerateSolutionFromMakefile { get; set; } = false;

    [Option(
        "source",
        Required = true,
        HelpText = "Source directory or file.")]
    public string Source { get; set; } = string.Empty;

    [Option(
        "name",
        Required = true,
        HelpText = "Name of generated file.")]
    public string Name { get; set; } = string.Empty;
}
