using BackEndForFrontEnd.Domain.Entities;
using BackEndForFrontEnd.Repositories.Interfaces;
using BackEndForFrontEnd.Services.Interfaces;
using Domain.DTOs;

namespace BackEndForFrontEnd.Services;

public class NewsService : INewsService
{
    private readonly INewsRepository _newsRepository;

    public NewsService(INewsRepository newsRepository)
    {
        _newsRepository = newsRepository;
    }

    public async Task<News> AddNewsAsync(CreateNews news)
    {
        var newNew = new News
        {
            Id = Guid.NewGuid(),
            Title = news.Title,
            Content = news.Content,
            Images = news.Images,
            Category = news.Category,
            CreationDate = DateTime.Now
        };
        var result = await _newsRepository.CreateAsync(newNew);

        if (result == null)
        {
            throw new ArgumentException("Failed to create news");
        }

        return newNew;
    }

    public async Task<bool> DeleteNewsAsync(Guid id)
    {
        var news = await _newsRepository.GetByIdAsync(id);
        if (news == null)
        {
            throw new ArgumentException("News not found");
        }
        return await _newsRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<News>> GetAllNewsAsync()
    {
        return await _newsRepository.GetAllAsync();
    }

    public async Task<IEnumerable<News>> GetLatestNewsAsync(int quantity)
    {
        return await _newsRepository.GetLatestNewsAsync(quantity);
    }

    public async Task<IEnumerable<News>> GetNewsByCategoryAsync(string category)
    {
        return await _newsRepository.GetNewsByCategoryAsync(category);
    }

    public async Task<News?> GetNewsByIdAsync(Guid id)
    {
        var news = await _newsRepository.GetByIdAsync(id);
        if(news == null)
        {
            throw new ArgumentException("News not found");
        }
        return news;
    }

    public async Task<(IEnumerable<News> News, int TotalCount)> GetPaginatedNewsAsync(int pageNumber, int pageSize)
    {
        return await _newsRepository.GetPaginatedNewsAsync(pageNumber, pageSize);
    }

    public async Task<IEnumerable<News>> SearchNewsAsync(string search)
    {
        return await _newsRepository.SearchNewsAsync(search);
    }

    public async Task<News> UpdateNewsAsync(Guid id, CreateNews news)
    {
        var existingNews = await _newsRepository.GetByIdAsync(id);
        if (existingNews == null)
        {
            throw new ArgumentException("News not found");
        }

        existingNews.Title = news.Title;
        existingNews.Content = news.Content;
        existingNews.Images = news.Images;
        existingNews.Category = news.Category;

        var result = await _newsRepository.UpdateAsync(existingNews);
        if (result == null)
        {
            throw new ArgumentException("Failed to update news");
        }

        return existingNews;
    }
}
