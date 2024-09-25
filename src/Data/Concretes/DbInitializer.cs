using System.Reflection;
using BackEndForFrontEnd.Data.Interfaces;
using Microsoft.Extensions.Options;
using DbUp;

namespace BackEndForFrontEnd.Data.Concretes;

public class DbInitializer : IDbInitializer
{
    private readonly DatabaseOptions _options;
    
    public DbInitializer(IOptions<DatabaseOptions> options)
    {
        _options = options.Value;
    }

    public void InitializeDatabase()
    {
        EnsureDatabase.For.PostgresqlDatabase(_options.DefaultConnection);

        var dpUp = DeployChanges.To
        .PostgresqlDatabase(_options.DefaultConnection)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .WithTransaction()
        .LogToConsole()
        .Build();

        var result = dpUp.PerformUpgrade();

        if (!result.Successful)
        {
            Console.WriteLine("Invalid Migrations");
        }
    }

}
