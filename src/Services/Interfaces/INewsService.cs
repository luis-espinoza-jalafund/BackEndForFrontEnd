using BackEndForFrontEnd.Domain.Entities;
using Domain.DTOs;

namespace BackEndForFrontEnd.Services.Interfaces;

public interface INewsService
{
    Task<IEnumerable<News>> GetAllNewsAsync();
    Task<News?> GetNewsByIdAsync(Guid id);
    Task<News> AddNewsAsync(CreateNews news);
    Task<News> UpdateNewsAsync(Guid id, CreateNews news);
    Task<bool> DeleteNewsAsync(Guid id);
    Task<IEnumerable<News>> GetNewsByCategoryAsync(string category);
    Task<IEnumerable<News>> SearchNewsAsync(string search);
    Task<IEnumerable<News>> GetLatestNewsAsync(int quantity);
    Task<(IEnumerable<News> News, int TotalCount)> GetPaginatedNewsAsync(int pageNumber, int pageSize);
}
