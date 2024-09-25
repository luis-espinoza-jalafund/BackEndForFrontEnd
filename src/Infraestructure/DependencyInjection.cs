using BackEndForFrontEnd.Data;
using BackEndForFrontEnd.Data.Concretes;
using BackEndForFrontEnd.Data.Interfaces;

namespace BackEndForFrontEnd.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.
            AddDataBase(configuration);
        return services;
    }

    private static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.ConnectionStrings));
        services.AddScoped<IDbConnectionFactory, DbConnection>();
        services.AddScoped<IDbInitializer, DbInitializer>();
        return services;
    }
}
