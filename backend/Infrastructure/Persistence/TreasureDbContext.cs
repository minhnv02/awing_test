using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class TreasureDbContext : DbContext
{
    public TreasureDbContext(DbContextOptions<TreasureDbContext> options) : base(options) { }

    public DbSet<TreasureMap> TreasureMaps { get; set; }
    public DbSet<MapCell> MapCells { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TreasureMap>()
            .HasMany(t => t.Cells)
            .WithOne(c => c.TreasureMap)
            .HasForeignKey(c => c.TreasureMapId);
    }
}
