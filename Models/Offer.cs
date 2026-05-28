namespace DealForge.API.Models;

public class Offer
{
    public long Id { get; set; }

    public long GameId { get; set; }

    public long StoreId { get; set; }

    public decimal OriginalPrice { get; set; }

    public decimal DiscountedPrice { get; set; }

    public decimal DiscountPercentage { get; set; }

    public string Currency { get; set; } = string.Empty;

    public string? OfferUrl { get; set; }

    public string? AffiliateUrl { get; set; }

    public bool IsActive { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Game Game { get; set; } = null!;

    public Store Store { get; set; } = null!;
}