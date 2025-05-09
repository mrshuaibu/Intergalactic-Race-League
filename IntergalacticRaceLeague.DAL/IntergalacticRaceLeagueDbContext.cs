using Microsoft.EntityFrameworkCore;
using IntergalacticRaceLeague.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace IntergalacticRaceLeague.DAL
{
    public class IntergalacticRaceLeagueDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Racer> Racers { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<RaceResult> RaceResults { get; set; }

        public DbSet<Statistics> Statistics { get; set; }

        public IntergalacticRaceLeagueDbContext(DbContextOptions<IntergalacticRaceLeagueDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Primary Key
            modelBuilder.Entity<Racer>()
                .HasKey(r => r.RacerId);

            modelBuilder.Entity<Tournament>()
                .HasKey(t => t.TournamentId);

            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.VehicleId);

            modelBuilder.Entity<RaceResult>()
                .HasKey(rr => rr.RaceResultId);

            modelBuilder.Entity<Statistics>()
                .HasKey(s => s.StatisticsId);

            //Relationships
            // One-to-One: Racer → Vehicle
            modelBuilder.Entity<Racer>()
                .HasOne(r => r.Vehicle)
                .WithOne(v => v.Racer)
                .HasForeignKey<Racer>(r => r.VehicleId);

            // One-to-Many: Tournament → RaceResult
            modelBuilder.Entity<RaceResult>()
                .HasOne(rr => rr.Tournament)
                .WithMany(t => t.RaceResults)
                .HasForeignKey(rr => rr.TournamentId);

            //many-to-many relationship
            modelBuilder.Entity<Tournament>()
                .HasMany(t => t.Racers)
                .WithMany(r => r.Tournaments)
                .UsingEntity<Dictionary<string, object>>(
                    "RacerTournament",
                    j => j.HasOne<Racer>().WithMany().HasForeignKey("RacerId"),
                    j => j.HasOne<Tournament>().WithMany().HasForeignKey("TournamentId"),
                    j =>
                    {
                        j.HasKey("RacerId", "TournamentId");
                        j.ToTable("RacerTournament");
                    }
                );

            modelBuilder.Entity<RaceResult>()
                .HasMany(rr => rr.Racers)
                .WithMany(t => t.RaceResults)
                .UsingEntity<Dictionary<string, object>>(
                    "RacerRaceResults",
                    j => j.HasOne<Racer>().WithMany().HasForeignKey("RacerId"),
                    j => j.HasOne<RaceResult>().WithMany().HasForeignKey("RaceResultId"),
                    j =>
                    {
                        j.HasKey("RacerId", "RaceResultId");
                        j.ToTable("RacerRaceResults");
                    }
                );

            //Property Constraints
            modelBuilder.Entity<Racer>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Racer>()
                .Property(r => r.Country)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Racer>()
                .Property(r => r.Age)
                .IsRequired();

            modelBuilder.Entity<RaceResult>()
                .Property(rr => rr.Position)
                .IsRequired();

            modelBuilder.Entity<Tournament>()
                .Property(t => t.TournamentName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Tournament>()
                .Property(t => t.StartDate)
                .IsRequired();

            modelBuilder.Entity<Tournament>()
                .Property(t => t.EndDate)
                .IsRequired();

            modelBuilder.Entity<Tournament>()
                .Property(t => t.Location)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Statistics>()
                .Property(s => s.TotalRacers)
                .IsRequired();

            modelBuilder.Entity<Statistics>()
                .Property(s => s.TotalTournaments)
                .IsRequired();

            modelBuilder.Entity<Statistics>()
                .Property(s => s.TotalVehicles)
                .IsRequired();
        }
    }
}
