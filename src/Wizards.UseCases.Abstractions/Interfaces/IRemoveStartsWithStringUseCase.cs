namespace Wizards.UseCases.Abstractions;

public interface IRemoveStartsWithStringUseCase
{
    Task<IEnumerable<string>> ExecuteAsync(
        IEnumerable<string> fulls,
        string startsWith,
        CancellationToken cancellationToken = default);
}
