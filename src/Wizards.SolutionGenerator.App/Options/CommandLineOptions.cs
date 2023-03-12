namespace Wizards.SolutionGenerator.App.Options;

public class CommandLineOptions
{
    // [Option('r', "read", Required = true, HelpText = "Input files to be processed.")]
    // public IEnumerable<string> InputFiles { get; set; } = null!;

    [Option('p', "path", Required = false, HelpText = "Path")]
    public string Path { get; set; } = string.Empty;

    // // Omitting long name, defaults to name of property, ie "--verbose"
    // [Option(Default = false, HelpText = "Prints all messages to standard output.")]
    // public bool Verbose { get; set; }

    // [Option("stdin", Default = false, HelpText = "Read from stdin")]
    // public bool StdIn { get; set; }

    // [Value(0, MetaName = "offset", HelpText = "File offset.")]
    // public long? Offset { get; set; }
}
