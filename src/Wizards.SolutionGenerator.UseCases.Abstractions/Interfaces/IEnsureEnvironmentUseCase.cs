namespace Wizards.SolutionGenerator.UseCases.Abstractions;

public interface IEnsureEnvironmentUseCase
{
    Task ExecuteAsync(CancellationToken cancellationToken = default);
}
