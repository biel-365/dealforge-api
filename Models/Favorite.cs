namespace DealForge.API.Models;

public class Favorite
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long GameId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User User { get; set; } = null!;

    public Game Game { get; set; } = null!;
}