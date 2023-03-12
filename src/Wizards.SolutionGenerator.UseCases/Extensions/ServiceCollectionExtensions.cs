namespace Wizards.SolutionGenerator.UseCases.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWizardsSolutionGeneratorUseCases(this IServiceCollection services)
    {
        services.AddWizardsUseCases();

        services.AddScoped<IGenerateMakefileUseCase, GenerateMakefileUseCase>();

        return services;
    }
}
