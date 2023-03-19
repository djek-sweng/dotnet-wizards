namespace Wizards.UseCases.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWizardsUseCases(this IServiceCollection services)
    {
        // Filesystem
        services.AddScoped<IFindCSharpProjectFilesUseCase, FindCSharpProjectFilesUseCase>();
        services.AddScoped<IRunShellCommandUseCase, RunShellCommandUseCase>();
        services.AddScoped<IWriteFileUseCase, WriteFileUseCase>();
        services.AddScoped<IReadFileUseCase, ReadFileUseCase>();
        services.AddScoped<IGetCurrentDirectoryUseCase, GetCurrentDirectoryUseCase>();
        services.AddScoped<IGetFileInfoUseCase, GetFileInfoUseCase>();

        // String
        services.AddScoped<IRemoveStringStartsWithUseCase, RemoveStringStartsWithUseCase>();

        return services;
    }
}
