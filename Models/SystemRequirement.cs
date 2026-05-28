namespace DealForge.API.Models;

public class SystemRequirement
{
    public long Id { get; set; }

    public long GameId { get; set; }

    public string OperatingSystem { get; set; } = string.Empty;

    public string Processor { get; set; } = string.Empty;

    public string Memory { get; set; } = string.Empty;

    public string GraphicsCard { get; set; } = string.Empty;

    public string Storage { get; set; } = string.Empty;

    public string? AdditionalInformation { get; set; }

    public string RequirementType { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Game Game { get; set; } = null!;
}