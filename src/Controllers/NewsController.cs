using Domain.DTOs;
using BackEndForFrontEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndForFrontEnd.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseNews), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNews([FromBody] CreateNews news)
        {
            var newNews = await _newsService.AddNewsAsync(news);
            Console.WriteLine(newNews.Category);
            var response = ResponseNews.FromDomain(newNews);
            return CreatedAtAction(nameof(GetNewsById), new { Id = newNews.Id }, response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseNews), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNewsById(Guid id)
        {
            var newsItem = await _newsService.GetNewsByIdAsync(id);
            if (newsItem == null)
            {
                return NotFound("News not found.");
            }
            var response = ResponseNews.FromDomain(newsItem);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ResponseNews>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllNews()
        {
            var newsItems = await _newsService.GetAllNewsAsync();
            var response = newsItems.Select(n => ResponseNews.FromDomain(n));
            return Ok(response);
        }

        [HttpGet("category/{category}")]
        [ProducesResponseType(typeof(IEnumerable<ResponseNews>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNewsByCategory(string category)
        {
            var newsItems = await _newsService.GetNewsByCategoryAsync(category);
            var response = newsItems.Select(n => ResponseNews.FromDomain(n));
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseNews), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateNews(Guid id, [FromBody] CreateNews news)
        {
            var updatedNews = await _newsService.UpdateNewsAsync(id, news);
            var response = ResponseNews.FromDomain(updatedNews);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteNews(Guid id)
        {
            await _newsService.DeleteNewsAsync(id);
            return NoContent();
        }
    }
}
