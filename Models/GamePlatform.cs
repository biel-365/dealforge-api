namespace DealForge.API.Models;

public class GamePlatform
{
    public long Id { get; set; }

    public long GameId { get; set; }

    public long PlatformId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Game Game { get; set; } = null!;

    public Platform Platform { get; set; } = null!;
}