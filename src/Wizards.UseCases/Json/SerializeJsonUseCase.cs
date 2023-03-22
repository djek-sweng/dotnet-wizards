namespace Wizards.UseCases.Json;

public class SerializeJsonUseCase : ISerializeJsonUseCase
{
    public Task<string> ExecuteAsync(
        object jsonObject,
        CancellationToken cancellationToken = default)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };

        var jsonString = JsonSerializer.Serialize(jsonObject, options);

        return Task.FromResult(jsonString);
    }
}
