namespace Wizards.Commands.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWizardsCommands(this IServiceCollection services)
    {
        // DotNet
        services.AddScoped<IDotNetNewSolutionCommand, DotNetNewSolutionCommand>();
        services.AddScoped<IDotNetSolutionAddCommand, DotNetSolutionAddCommand>();

        return services;
    }
}
