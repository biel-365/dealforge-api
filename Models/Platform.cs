namespace DealForge.API.Models;

public class Platform
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? IconUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ICollection<GamePlatform> GamePlatforms { get; set; } = new List<GamePlatform>();
}