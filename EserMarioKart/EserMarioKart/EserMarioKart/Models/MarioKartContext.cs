using Microsoft.EntityFrameworkCore;

namespace EserMarioKart.Models
{
    public class MarioKartContext : DbContext
    {
        public MarioKartContext(DbContextOptions<MarioKartContext> options) : base(options)
        {

        }

        public DbSet<Personaggio> Personaggio { get; set; }
        public DbSet<Squadra> Squadra { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Squadra>()
            .HasKey(s => new { s.SquadraID });
            modelBuilder.Entity<Personaggio>()
            .HasKey(p => new { p.PersonaggioID });

            modelBuilder.Entity<Squadra>()
            .HasMany(e => e.Personaggios)
            .WithOne(e => e.SquadraRIFNavigation)
            .HasForeignKey(e => e.SquadraRIF)
            .IsRequired(false);

            modelBuilder.Entity<Personaggio>()
            .HasOne(p => p.SquadraRIFNavigation)
            .WithMany(s => s.Personaggios)
            .HasForeignKey(p => p.SquadraRIF)
            .IsRequired(false);
        }
    }
}
