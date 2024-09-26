using System.Data;
using BackEndForFrontEnd.Data.Interfaces;
using Microsoft.Extensions.Options;
using Npgsql;

namespace BackEndForFrontEnd.Data.Concretes;

public class DbConnection : IDbConnectionFactory
{
    private readonly DatabaseOptions _options;

    public DbConnection(IOptions<DatabaseOptions> options)
    {
        _options = options.Value;
    }

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new NpgsqlConnection(_options.DefaultConnection);
        await connection.OpenAsync();
        return connection;
    }

}
