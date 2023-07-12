using Application.Interfaces;
using Application.Services;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class DependencyInjectionContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        /* Application */
        services.AddScoped<IJwtService, JwtService>();
        
        /* Repository */
        services.AddScoped<IBlogPostRepository, BlogPostRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
    }
}