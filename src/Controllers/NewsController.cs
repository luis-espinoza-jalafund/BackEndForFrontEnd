using Domain.DTOs;
using BackEndForFrontEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace BackEndForFrontEnd.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        private bool IsMobileRequest(HttpRequest request)
        {
            var userAgent = request.Headers["User-Agent"].ToString();
            return Regex.IsMatch(userAgent, 
                "(android|bb\\d+|meego).+mobile|" +
                "avantgo|bada\\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|" +
                "ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|" +
                "opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\\/|plucker|pocket|psp|" +
                "series(4|6)0|symbian|treo|up\\.(browser|link)|vodafone|wap|windows ce|" +
                "xda|xiino", 
                RegexOptions.IgnoreCase);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseNews), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNews([FromBody] CreateNews news)
        {
            var newNews = await _newsService.AddNewsAsync(news);
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
            var isMobile = IsMobileRequest(Request);
            int? limit = isMobile ? 20 : null;
            var newsItems = await _newsService.GetAllNewsAsync(limit);
            var response = newsItems.Select(n => ResponseNews.FromDomain(n));
            return Ok(response);
        }

        [HttpGet("category/{category}")]
        [ProducesResponseType(typeof(IEnumerable<ResponseNews>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNewsByCategory(string category)
        {
            var isMobile = IsMobileRequest(Request);
            int? limit = isMobile ? 15 : null;
            var newsItems = await _newsService.GetNewsByCategoryAsync(category, limit);
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

        [HttpGet("latest/{quantity}")]
        [ProducesResponseType(typeof(IEnumerable<ResponseNews>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLatestNews(int quantity)
        {
            var newsItems = await _newsService.GetLatestNewsAsync(quantity);
            var response = newsItems.Select(n => ResponseNews.FromDomain(n));
            return Ok(response);
        }

        [HttpGet("search/{search}")]
        [ProducesResponseType(typeof(IEnumerable<ResponseNews>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchNews(string search)
        {
            var isMobile = IsMobileRequest(Request);
            int? limit = isMobile ? 20 : null;
            var newsItems = await _newsService.SearchNewsAsync(search, limit);
            var response = newsItems.Select(n => ResponseNews.FromDomain(n));
            return Ok(response);
        }

        [HttpGet("paginated")]
        [ProducesResponseType(typeof(PaginatedResponse<ResponseNews>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaginatedNews(int pageNumber, int pageSize)
        {
            var (newsItems, totalCount) = await _newsService.GetPaginatedNewsAsync(pageNumber, pageSize);
            
            if (!newsItems.Any())
            {
                return NotFound("No news found for the requested page.");
            }

            var response = new PaginatedResponse<ResponseNews>
            {
                Items = newsItems.Select(n => ResponseNews.FromDomain(n)).ToList(),
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(response);
        }

    }
}
