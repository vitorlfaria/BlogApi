using Application.AutoMapper;
using AutoMapper;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace BlogApi.Configurations;

public static class AutoMapperSetup
{
    public static void AddAutoMapperSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddSingleton<IConfigurationProvider>(AutoMapperConfig.RegisterMappings());
        services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
    }
}