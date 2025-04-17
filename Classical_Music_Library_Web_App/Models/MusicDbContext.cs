using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Classical_Music_Library_Web_App.Models
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options)
            : base(options) { }

        public DbSet<Composer> Composers { get; set; }
        public DbSet<Composition> Compositions { get; set; }
        public DbSet<EnsembleType> EnsembleTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Recording> Recordings { get; set; }
        public DbSet<LibraryInventory> LibraryInventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Composition>(entity =>
            {
                entity.HasOne(c => c.Composer)
                    .WithMany(c => c.Compositions)
                    .HasForeignKey(c => c.ComposerID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.EnsembleType)
                    .WithMany(e => e.Compositions)
                    .HasForeignKey(c => c.EnsembleTypeID)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(c => c.Genre)
                    .WithMany(g => g.Compositions)
                    .HasForeignKey(c => c.GenreID)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Recording>(entity =>
            {
                entity.HasOne(r => r.Composition)
                    .WithMany(c => c.Recordings)
                    .HasForeignKey(r => r.CompositionID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r => r.EnsembleType)
                    .WithMany(e => e.Recordings)
                    .HasForeignKey(r => r.EnsembleTypeID)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(r => r.Genre)
                    .WithMany(g => g.Recordings)
                    .HasForeignKey(r => r.GenreID)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<LibraryInventory>(entity =>
            {
                entity.HasOne(li => li.Recording)
                    .WithMany(r => r.LibraryInventories)
                    .HasForeignKey(li => li.RecordingID)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}