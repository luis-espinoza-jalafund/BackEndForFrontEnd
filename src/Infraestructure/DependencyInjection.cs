using BackEndForFrontEnd.Data;
using BackEndForFrontEnd.Data.Concretes;
using BackEndForFrontEnd.Data.Interfaces;
using BackEndForFrontEnd.Repositories;
using BackEndForFrontEnd.Repositories.Interfaces;
using BackEndForFrontEnd.Services;
using BackEndForFrontEnd.Services.Interfaces;

namespace BackEndForFrontEnd.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDataBase(configuration)
            .AddRepositories()
            .AddServices();
        return services;
    }

    private static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.ConnectionStrings));
        services.AddScoped<IDbConnectionFactory, DbConnection>();
        services.AddScoped<IDbInitializer, DbInitializer>();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<INewsRepository, NewsRepository>();
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<INewsService, NewsService>();
        return services;
    }
}
