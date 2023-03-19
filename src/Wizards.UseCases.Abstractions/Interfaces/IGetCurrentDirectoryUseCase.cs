namespace Wizards.UseCases.Abstractions;

public interface IGetCurrentDirectoryUseCase
{
    Task<string> Execute(CancellationToken cancellationToken = default);
}
