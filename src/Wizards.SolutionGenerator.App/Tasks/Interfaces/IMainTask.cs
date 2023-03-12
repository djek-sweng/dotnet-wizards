namespace Wizards.SolutionGenerator.App.Tasks;

public interface IMainTask
{
    Task ExecuteAsync(
        IEnumerable<string> args,
        CancellationToken cancellationToken = default);
}
