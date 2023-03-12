namespace Wizards.SolutionGenerator.App.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWizardsSolutionGenerator(this IServiceCollection services)
    {
        services.AddLogging(options =>
            options.AddConsole(opts => opts.LogToStandardErrorThreshold = LogLevel.Debug));

        services.AddScoped<IMainTask, MainTask>();

        return services;
    }
}
