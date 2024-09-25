using System.Data;

namespace BackEndForFrontEnd.Data.Interfaces;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync();
}
