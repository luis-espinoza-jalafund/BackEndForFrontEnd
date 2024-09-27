using BackEndForFrontEnd.Domain.Entities;

namespace Domain.DTOs
{
    public record ResponseUser
    (
        Guid Id,
        string Name,
        string Description,
        string ProfileImage
    )
    {
        public static ResponseUser FromDomain(User user)
        {
            return new ResponseUser
            (
                user.Id,
                user.Name,
                user.Description,
                user.ProfileImage
            );
        }
    }
}
