namespace DealForge.API.Models;

public class Store
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string? LogoUrl { get; set; }

    public string? WebsiteUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ICollection<Offer> Offers { get; set; } = new List<Offer>();
}