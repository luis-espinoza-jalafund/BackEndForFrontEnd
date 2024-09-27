using BackEndForFrontEnd.Data.Interfaces;
using BackEndForFrontEnd.Domain.Entities;
using BackEndForFrontEnd.Repositories.Interfaces;
using Dapper;

namespace BackEndForFrontEnd.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionFactory _dbConnection;

    public UserRepository(IDbConnectionFactory dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<User?> CreateAsync(User entity)
    {
        const string sql = @"
            INSERT INTO Users (Name, Description, ProfileImage)
            VALUES (@Name, @Description, @ProfileImage)
            RETURNING Id, Name, Description, ProfileImage";

        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QueryFirstOrDefaultAsync<User>(sql, entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        const string sql = "DELETE FROM Users WHERE Id = @Id";

        using var connection = await _dbConnection.CreateConnectionAsync();
        var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
        return affectedRows > 0;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        const string sql = "SELECT Id, Name, Description, ProfileImage FROM Users";

        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QueryAsync<User>(sql);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        const string sql = "SELECT Id, Name, Description, ProfileImage FROM Users WHERE Id = @Id";

        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
    }

    public async Task<User?> GetByNameAsync(string name)
    {
        const string sql = "SELECT Id, Name, Description, ProfileImage FROM Users WHERE Name = @Name";

        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<User>(sql, new { Name = name });
    }

    public async Task<User?> UpdateAsync(User entity)
    {
        const string sql = @"
            UPDATE Users
            SET Name = @Name, Description = @Description, ProfileImage = @ProfileImage
            WHERE Id = @Id
            RETURNING Id, Name, Description, ProfileImage";
        
        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<User>(sql, entity);
    }
}
