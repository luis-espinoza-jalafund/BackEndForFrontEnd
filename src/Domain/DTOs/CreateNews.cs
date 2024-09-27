using BackEndForFrontEnd.Domain.Entities;

namespace Domain.DTOs
{
    public record CreateNews
    (
        string Title,
        string Content,
        string Images,
        string Category,
        DateTime CreationDate
    )
    {
        public News ToDomain()
        {
            return new News
            {
                Title = Title,
                Content = Content,
                Images = Images,
                Category = Category,
                CreationDate = CreationDate
            };
        }
    }
}
