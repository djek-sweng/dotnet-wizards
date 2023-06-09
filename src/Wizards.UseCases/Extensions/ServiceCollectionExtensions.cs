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
        services.AddScoped<IChangeDirectoryUseCase, ChangeDirectoryUseCase>();
        services.AddScoped<IRemoveFileUseCase, RemoveFileUseCase>();
        services.AddScoped<IEnsureFileExistsUseCase, EnsureFileExistsUseCase>();

        // Json
        services.AddScoped<ISerializeJsonUseCase, SerializeJsonUseCase>();
        services.AddScoped<IDeserializeJsonUseCase, DeserializeJsonUseCase>();

        // String
        services.AddScoped<IRemoveStartsWithStringUseCase, RemoveStartsWithStringUseCase>();
        services.AddScoped<IAppendDirectorySeparatorCharUseCase, AppendDirectorySeparatorCharUseCase>();

        return services;
    }
}
