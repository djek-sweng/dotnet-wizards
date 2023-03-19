namespace Wizards.UseCases.Json;

public class DeserializeJsonUseCase : IDeserializeJsonUseCase
{
    public Task<T> ExecuteAsync<T>(
        string jsonString,
        CancellationToken cancellationToken = default)
    {
        var jsonObject = JsonSerializer.Deserialize<T>(jsonString);

        if (jsonObject == null)
        {
            throw new NullReferenceException();
        }

        return Task.FromResult<T>(jsonObject);
    }
}
