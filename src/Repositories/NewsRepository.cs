using BackEndForFrontEnd.Data.Interfaces;
using BackEndForFrontEnd.Domain.Entities;
using BackEndForFrontEnd.Repositories.Interfaces;
using Dapper;

namespace BackEndForFrontEnd.Repositories;

public class NewsRepository : INewsRepository
{
    private readonly IDbConnectionFactory _dbConnection;

    public NewsRepository(IDbConnectionFactory dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<News?> CreateAsync(News entity)
    {
        const string sql = @"
            INSERT INTO News (Id, Title, Content, Images, Category, CreationDate)
            VALUES (@Id, @Title, @Content, @Images, @Category, @CreationDate)
            RETURNING Id, Title, Content, Images, Category, CreationDate";
        
        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<News>(sql, entity);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        const string sql = "DELETE FROM News WHERE Id = @Id";

        using var connection = await _dbConnection.CreateConnectionAsync();
        var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
        return affectedRows > 0;
    }

    public async Task<IEnumerable<News>> GetAllAsync(int? limit = null)
    {
        string sql = "SELECT Id, Title, Content, Images, Category, CreationDate FROM News ORDER BY CreationDate DESC";

         if (limit.HasValue && limit > 0)
        {
            sql += " LIMIT @Limit";
        }
        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QueryAsync<News>(sql, new { Limit = limit });
    }

    public async Task<News?> GetByIdAsync(Guid id)
    {
        const string sql = "SELECT Id, Title, Content, Images, Category, CreationDate FROM News WHERE Id = @Id";

        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<News>(sql, new { Id = id });
    }

    public async Task<IEnumerable<News>> GetLatestNewsAsync(int quantity)
    {
        const string sql = @"
            SELECT Id, Title, Content, Images, Category, CreationDate 
            FROM News 
            ORDER BY CreationDate DESC 
            LIMIT @Quantity";

        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QueryAsync<News>(sql, new { Quantity = quantity });
    }

    public async Task<IEnumerable<News>> GetNewsByCategoryAsync(string category, int? limit = null)
    {
        string sql = @"
            SELECT Id, Title, Content, Images, Category, CreationDate 
            FROM News 
            WHERE Category = @Category";
        if (limit.HasValue && limit > 0)
        {
            sql += " LIMIT @Limit";
        }
        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QueryAsync<News>(sql, new { Category = category, Limit = limit });
    }

    public async Task<(IEnumerable<News> News, int TotalCount)> GetPaginatedNewsAsync(int pageNumber, int pageSize)
    {
        const string sqlCount = "SELECT COUNT(*) FROM News";
        const string sqlPaginated = @"
            SELECT Id, Title, Content, Images, Category, CreationDate 
            FROM News 
            ORDER BY CreationDate DESC 
            OFFSET @Offset LIMIT @Limit";

        using var connection = await _dbConnection.CreateConnectionAsync();
        var totalCount = await connection.ExecuteScalarAsync<int>(sqlCount);
        var news = await connection.QueryAsync<News>(sqlPaginated, new 
        { 
            Offset = (pageNumber - 1) * pageSize, 
            Limit = pageSize 
        });

        return (news, totalCount);
    }

    public async Task<IEnumerable<News>> SearchNewsAsync(string search, int? limit = null)
    {
        string sql = @"
            SELECT Id, Title, Content, Images, Category, CreationDate 
            FROM News 
            WHERE Title ILIKE @Search OR Content ILIKE @Search";
        if (limit.HasValue && limit > 0)
        {
            sql += " LIMIT @Limit";
        }

        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QueryAsync<News>(sql, new { Search = $"%{search}%", Limit = limit });
    }

    public async Task<News?> UpdateAsync(News entity)
    {
        const string sql = @"
            UPDATE News 
            SET Title = @Title, Content = @Content, Images = @Images, Category = @Category
            WHERE Id = @Id
            RETURNING Id, Title, Content, Images, Category, CreationDate";

        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<News>(sql, entity);
    }
}
