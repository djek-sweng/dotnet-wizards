namespace Wizards.SolutionGenerator.Executable.Tasks;

public interface IMainTask
{
    Task ExecuteAsync(
        IEnumerable<string> args,
        CancellationToken cancellationToken = default);
}
