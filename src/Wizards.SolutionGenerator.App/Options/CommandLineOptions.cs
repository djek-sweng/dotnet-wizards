namespace Wizards.SolutionGenerator.App.Options;

public class CommandLineOptions
{
    [Option("generate-makefile", Required = false, HelpText = "GenerateMakefile")]
    public bool GenerateMakefile { get; set; } = false;

    [Option("generate-solution", Required = false, HelpText = "GenerateSolution")]
    public bool GenerateSolution { get; set; } = false;

    // [Option('s', "src", Required = false, HelpText = "Source")]
    // public string Source { get; set; } = string.Empty;

    // [Option('d', "dst", Required = false, HelpText = "Destination")]
    // public string Destination { get; set; } = string.Empty;

    [Option('o', "out", Required = false, HelpText = "Output")]
    public string Output { get; set; } = string.Empty;

    [Option('p', "path", Required = false, HelpText = "Path")]
    public string Path { get; set; } = string.Empty;

    [Option('n', "name", Required = false, HelpText = "Name")]
    public string Name { get; set; } = string.Empty;

    // [Option('r', "read", Required = true, HelpText = "Input files to be processed.")]
    // public IEnumerable<string> InputFiles { get; set; } = null!;

    // // Omitting long name, defaults to name of property, ie "--verbose"
    // [Option(Default = false, HelpText = "Prints all messages to standard output.")]
    // public bool Verbose { get; set; }

    // [Option("stdin", Default = false, HelpText = "Read from stdin")]
    // public bool StdIn { get; set; }

    // [Value(0, MetaName = "offset", HelpText = "File offset.")]
    // public long? Offset { get; set; }
}
