using BackEndForFrontEnd.Domain.Entities;
using Domain.DTOs;

namespace BackEndForFrontEnd.Services.Interfaces;

public interface INewsService
{
    Task<IEnumerable<News>> GetAllNewsAsync(int? limit = null);
    Task<News?> GetNewsByIdAsync(Guid id);
    Task<News> AddNewsAsync(CreateNews news);
    Task<News> UpdateNewsAsync(Guid id, CreateNews news);
    Task<bool> DeleteNewsAsync(Guid id);
    Task<IEnumerable<News>> GetNewsByCategoryAsync(string category, int? limit = null);
    Task<IEnumerable<News>> SearchNewsAsync(string search, int? limit = null);
    Task<IEnumerable<News>> GetLatestNewsAsync(int quantity);
    Task<(IEnumerable<News> News, int TotalCount)> GetPaginatedNewsAsync(int pageNumber, int pageSize);
}
