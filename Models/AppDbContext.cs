using DealForge.API.Models;
using Microsoft.EntityFrameworkCore;

namespace dealforgeApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Offer> Offers => Set<Offer>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Store> Stores => Set<Store>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Platform> Platforms => Set<Platform>();
    public DbSet<Favorite> Favorites => Set<Favorite>();
    public DbSet<SystemRequirement> SystemRequirements => Set<SystemRequirement>();
    public DbSet<GameGenre> GameGenres => Set<GameGenre>();
    public DbSet<GamePlatform> GamePlatforms => Set<GamePlatform>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(user => user.Email).IsUnique();
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasIndex(game => game.Slug).IsUnique();
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasIndex(store => store.Slug).IsUnique();
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasOne(offer => offer.Game)
                .WithMany(game => game.Offers)
                .HasForeignKey(offer => offer.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(offer => offer.Store)
                .WithMany(store => store.Offers)
                .HasForeignKey(offer => offer.StoreId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasOne(review => review.Game)
                .WithMany(game => game.Reviews)
                .HasForeignKey(review => review.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<SystemRequirement>(entity =>
        {
            entity.HasOne(requirement => requirement.Game)
                .WithMany(game => game.SystemRequirements)
                .HasForeignKey(requirement => requirement.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasOne(favorite => favorite.User)
                .WithMany(user => user.Favorites)
                .HasForeignKey(favorite => favorite.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(favorite => favorite.Game)
                .WithMany(game => game.Favorites)
                .HasForeignKey(favorite => favorite.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(favorite => new { favorite.UserId, favorite.GameId }).IsUnique();
        });

        modelBuilder.Entity<GameGenre>(entity =>
        {
            entity.HasOne(gameGenre => gameGenre.Game)
                .WithMany(game => game.GameGenres)
                .HasForeignKey(gameGenre => gameGenre.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(gameGenre => gameGenre.Genre)
                .WithMany(genre => genre.GameGenres)
                .HasForeignKey(gameGenre => gameGenre.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(gameGenre => new { gameGenre.GameId, gameGenre.GenreId }).IsUnique();
        });

        modelBuilder.Entity<GamePlatform>(entity =>
        {
            entity.HasOne(gamePlatform => gamePlatform.Game)
                .WithMany(game => game.GamePlatforms)
                .HasForeignKey(gamePlatform => gamePlatform.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(gamePlatform => gamePlatform.Platform)
                .WithMany(platform => platform.GamePlatforms)
                .HasForeignKey(gamePlatform => gamePlatform.PlatformId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(gamePlatform => new { gamePlatform.GameId, gamePlatform.PlatformId }).IsUnique();
        });
    }
}