namespace Wizards.UseCases.Abstractions;

public interface IRemoveStringStartsWithUseCase
{
    Task<IEnumerable<string>> ExecuteAsync(
        IEnumerable<string> fulls,
        string startsWith,
        CancellationToken cancellationToken = default);
}
