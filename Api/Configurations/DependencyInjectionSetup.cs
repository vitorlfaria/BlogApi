using Infrastructure.IoC;

namespace BlogApi.Configurations;

public static class DependencyInjectionSetup
{
    public static void AddDependencyInjectionSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddSingleton<ILoggerFactory, LoggerFactory>();

        DependencyInjectionContainer.RegisterServices(services);
    }
}