namespace DealForge.API.Models;

public class GameGenre
{
    public long Id { get; set; }

    public long GameId { get; set; }

    public long GenreId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Game Game { get; set; } = null!;

    public Genre Genre { get; set; } = null!;
}