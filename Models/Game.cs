using System.ComponentModel.DataAnnotations;

namespace DealForge.API.Models;

public class Game
{
    public long Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Slug { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Developer { get; set; }

    public string? Publisher { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string? CoverImageUrl { get; set; }

    public string? BannerImageUrl { get; set; }

    public decimal? MetacriticScore { get; set; }

    public string? AgeRating { get; set; }

    public string? TrailerUrl { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public ICollection<SystemRequirement> SystemRequirements { get; set; } = new List<SystemRequirement>();

    public ICollection<GamePlatform> GamePlatforms { get; set; } = new List<GamePlatform>();

    public ICollection<GameGenre> GameGenres { get; set; } = new List<GameGenre>();

    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}