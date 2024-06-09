using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities.Configs;

namespace WebApplication1.Entities;

public class MusicDbContext : DbContext
{
    public virtual DbSet<Muzyk> Muzycy { get; set; }
    public virtual DbSet<Utwor> Utwory { get; set; }

    public MusicDbContext()
    {
    }

    public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MuzykEfConfig).Assembly);
    }
}