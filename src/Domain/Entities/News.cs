namespace BackEndForFrontEnd.Domain.Entities;

public class News
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string Images { get; set; }
    public required string Category { get; set; }
    public DateTime CreationDate { get; set; }
}
