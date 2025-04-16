using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Classical_Music_Library_Web_App.Models
{
    public class MusicDbContext : DbContext
    {
       public MusicDbContext(DbContextOptions<MusicDbContext> options)
           : base(options) { } // Constructor for the DbContext

        //Database Tables
        public DbSet<Composer> Composers { get; set; }
        public DbSet<Composition> Compositions { get; set; }
        public DbSet<EnsembleType> EnsembleTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Recording> Recordings { get; set; }
        public DbSet<LibraryInventory> LibraryInventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuring composition relationships between the tables
            modelBuilder.Entity<Composition>(entity =>
            {

                entity.HasOne(c => c.Composer)
                      .WithMany(c => c.Compositions)
                      .HasForeignKey(c => c.ComposerID)
                      .OnDelete(DeleteBehavior.Restrict); //Prevent composer deletion with compositions

                entity.HasOne(c => c.EnsembleType)      //Compositions relationship with EnsembleType
                      .WithMany(e => e.Compositions)
                      .HasForeignKey(c => c.EnsembleTypeID)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(c => c.Genre)             //Composition relationship with Genre
                     .WithMany(g => g.Compositions)
                     .HasForeignKey(c => c.GenreID)
                     .OnDelete(DeleteBehavior.SetNull);

            });

            //Configuring Recording relationships between the tables
            modelBuilder.Entity<Recording>(entity =>
            {
                entity.HasOne(r => r.Composition)
                      .WithMany(c => c.Recordings)
                      .HasForeignKey(r => r.CompositionID)
                      .OnDelete(DeleteBehavior.Cascade); //Prevent deletion of recordings when composition is deleted

                entity.HasOne(r => r.EnsembleType)      //Recording relationship with EnsembleType
                      .WithMany(e => e.Recordings)
                      .HasForeignKey(r => r.EnsembleTypeID)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(r => r.Genre)             //Recording relationship with Genre
                      .WithMany(g => g.Recordings)
                      .HasForeignKey(r => r.GenreID)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            //Configuring Library Inventory relationships between the tables
            modelBuilder.Entity<LibraryInventory>(entity =>
            { 
                entity.HasOne(li => li.Recording)
                      .WithMany(r => r.LibraryInventories)
                      .HasForeignKey(li => li.RecordingID)
                      .OnDelete(DeleteBehavior.Cascade); // Delete recordings when composition is deleted
            });
        }
    }
}
