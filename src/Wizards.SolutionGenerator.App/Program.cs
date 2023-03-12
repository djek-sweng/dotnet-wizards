namespace Wizards.SolutionGenerator.App;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        using var host = Host.CreateDefaultBuilder(/*args*/)
            .ConfigureServices(services =>
            {
                services.AddWizardsSolutionGenerator();
                services.AddWizardsSolutionGeneratorUseCases();
            })
            .Build();

        using var scope = host.Services.CreateScope();

        var mainTask = scope.ServiceProvider.GetRequiredService<IMainTask>();

        await mainTask.ExecuteAsync(args);
    }
}
