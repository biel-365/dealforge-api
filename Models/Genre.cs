namespace DealForge.API.Models;

public class Genre
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ICollection<GameGenre> GameGenres { get; set; } = new List<GameGenre>();
}