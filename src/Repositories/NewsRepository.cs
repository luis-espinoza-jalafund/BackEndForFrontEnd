using BackEndForFrontEnd.Data.Interfaces;
using BackEndForFrontEnd.Domain.Entities;
using BackEndForFrontEnd.Repositories.Interfaces;

namespace BackEndForFrontEnd.Repositories;

public class NewsRepository : INewsRepository
{
    private readonly IDbConnectionFactory _dbConnection;

    public NewsRepository(IDbConnectionFactory dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public Task<News> CreateAsync(News entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<News>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<News> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<News>> GetLatestNewsAsync(int quantity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<News>> GetNewsByCategoryAsync(string category)
    {
        throw new NotImplementedException();
    }

    public Task<(IEnumerable<News> News, int TotalCount)> GetPaginatedNewsAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<News>> SearchNewsAsync(string search)
    {
        throw new NotImplementedException();
    }

    public Task<News> UpdateAsync(News entity)
    {
        throw new NotImplementedException();
    }

}
