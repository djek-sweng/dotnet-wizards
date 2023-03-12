namespace Wizards.UseCases.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWizardsUseCases(this IServiceCollection services)
    {
        // Filesystem
        services.AddScoped<IFindCSharpProjectFilesUseCase, FindCSharpProjectFilesUseCase>();
        services.AddScoped<IWriteFileUseCase, WriteFileUseCase>();

        // String
        services.AddScoped<IRemoveStringStartsWithUseCase, RemoveStringStartsWithUseCase>();

        return services;
    }
}
