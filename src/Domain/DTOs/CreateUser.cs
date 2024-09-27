using BackEndForFrontEnd.Domain.Entities;

namespace Domain.DTOs
{
    public record CreateUser
    (
        string Name,
        string Description,
        string ProfileImage
    )
    {
        public User ToDomain()
        {
            return new User
            {
                Name = Name,
                Description = Description,
                ProfileImage = ProfileImage
            };
        }
    }
}
