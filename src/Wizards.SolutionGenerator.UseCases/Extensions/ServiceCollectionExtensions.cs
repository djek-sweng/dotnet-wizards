namespace Wizards.SolutionGenerator.UseCases.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWizardsSolutionGeneratorUseCases(this IServiceCollection services)
    {
        // Libraries
        services.AddWizardsCommands();
        services.AddWizardsUseCases();

        // Filesystem
        services.AddScoped<IGenerateMakefileModelUseCase, GenerateMakefileModelUseCase>();
        services.AddScoped<IGenerateMakefileStringUseCase, GenerateMakefileStringUseCase>();
        services.AddScoped<IGenerateMakefileUseCase, GenerateMakefileUseCase>();
        services.AddScoped<IGenerateSolutionUseCase, GenerateSolutionUseCase>();

        return services;
    }
}
