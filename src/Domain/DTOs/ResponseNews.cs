using BackEndForFrontEnd.Domain.Entities;

namespace Domain.DTOs
{
    public record ResponseNews
    (
        Guid Id,
        string Title,
        string Content,
        string Images,
        string Category,
        string CreationDate
    )
    {
        public static ResponseNews FromDomain(News news)
        {
            return new ResponseNews
            (
                news.Id,
                news.Title,
                news.Content,
                news.Images,
                news.Category,
                news.CreationDate.ToString("yyyy-MM-ddTHH:mm:ssZ")
            );
        }
    }
}
