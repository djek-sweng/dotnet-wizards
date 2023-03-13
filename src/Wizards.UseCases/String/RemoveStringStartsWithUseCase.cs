namespace Wizards.UseCases.String;

public class RemoveStringStartsWithUseCase : IRemoveStringStartsWithUseCase
{
    public Task<IEnumerable<string>> ExecuteAsync(
        IEnumerable<string> fulls,
        string startsWith,
        CancellationToken cancellationToken = default)
    {
        var relatives = new List<string>();

        foreach (var full in fulls)
        {
            var relative = full;

            var index = full.IndexOf(startsWith, StringComparison.Ordinal);
            if (index > -1)
            {
                relative = full[startsWith.Length ..];
            }

            relatives.Add(relative);
        }

        return Task.FromResult<IEnumerable<string>>(relatives);
    }
}
