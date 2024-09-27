namespace BackEndForFrontEnd.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string ProfileImage { get; set; }
}
