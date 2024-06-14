using Microsoft.EntityFrameworkCore;
using GameStore.Entities;

namespace GameStore.Data
{
  public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
  {
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Genre>().HasData(
        new { Id = 1, Title = "Action" },
        new { Id = 2, Title = "Sports" },
        new { Id = 3, Title = "Racing" },
        new { Id = 4, Title = "Survival" }
      );
    }
  }
}