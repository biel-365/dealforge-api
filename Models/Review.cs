namespace DealForge.API.Models;

public class Review
{
    public long Id { get; set; }

    public long GameId { get; set; }

    public string Source { get; set; } = string.Empty;

    public decimal Score { get; set; }

    public int ReviewCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Game Game { get; set; } = null!;
}