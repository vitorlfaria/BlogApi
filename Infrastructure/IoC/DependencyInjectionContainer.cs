using Domain.Interfaces.Repositories;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class DependencyInjectionContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        /* Repository */
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBlogPostRepository, BlogPostRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
    }
}