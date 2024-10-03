using BackEndForFrontEnd.Domain.Entities;

namespace BackEndForFrontEnd.Repositories.Interfaces;

public interface INewsRepository : IRepository<News>
{
    Task<IEnumerable<News>> GetNewsByCategoryAsync(string category, int? limit = null);
    Task<IEnumerable<News>> SearchNewsAsync(string search, int? limit = null );
    Task<IEnumerable<News>> GetLatestNewsAsync(int quantity);
    Task<(IEnumerable<News> News, int TotalCount)> GetPaginatedNewsAsync(int pageNumber, int pageSize);
}
