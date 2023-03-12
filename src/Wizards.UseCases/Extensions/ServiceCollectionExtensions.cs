namespace Wizards.UseCases.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWizardsUseCases(this IServiceCollection services)
    {
        services.AddScoped<IFindCSharpProjectFilesUseCase, FindCSharpProjectFilesUseCase>();

        return services;
    }
}
