namespace Wizards.UseCases.Json;

public class DeserializeJsonUseCase : IDeserializeJsonUseCase
{
    public Task<T?> ExecuteAsync<T>(
        string jsonString,
        CancellationToken cancellationToken = default)
    {
        var jsonObject = JsonSerializer.Deserialize<T>(jsonString);

        return Task.FromResult(jsonObject);
    }
}
