using Microsoft.EntityFrameworkCore;
using Classical_Music_Library_Web_App.Models;

namespace Classical_Music_Library_Web_App.Data
{
    /// <summary>
    /// Main database context class that bridges C# code with SQL Server.
    /// Handles all database operations (CRUD, queries, relationships).
    /// </summary>
    public class MusicDbContext : DbContext
    {
        // Constructor: Accepts DbContextOptions via dependency injection
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
        {
        }

        //--- DbSets (Database Tables) ---//

        /// <summary>
        /// Composers table (e.g., Beethoven, Mozart).
        /// </summary>
        public DbSet<Composer> Composers { get; set; }

        /// <summary>
        /// Ensemble types table (e.g., Orchestra, String Quartet).
        /// </summary>
        public DbSet<EnsembleType> EnsembleTypes { get; set; }

        /// <summary>
        /// Genres table (e.g., Symphony, Concerto).
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Compositions table (e.g., Symphony No. 5).
        /// </summary>
        public DbSet<Composition> Compositions { get; set; }

        /// <summary>
        /// Recordings table (specific performances of compositions).
        /// </summary>
        public DbSet<Recording> Recordings { get; set; }

        /// <summary>
        /// Library inventory table (physical/digital copies).
        /// </summary>
        public DbSet<LibraryInventory> LibraryInventories { get; set; }

        //--- Database Configuration ---//

        /// <summary>
        /// Configures relationships between tables and constraints.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //--- COMPOSER RELATIONSHIPS ---//

            // 1 Composer → Many Compositions
            modelBuilder.Entity<Composition>()
                .HasOne(c => c.Composer)              // A Composition has one Composer
                .WithMany(c => c.Compositions)        // A Composer has many Compositions
                .HasForeignKey(c => c.ComposerID)     // Foreign key: ComposerID
                .OnDelete(DeleteBehavior.Cascade);    // Delete compositions if composer is deleted

            //--- ENSEMBLE TYPE RELATIONSHIPS ---//

            // 1 EnsembleType → Many Compositions
            modelBuilder.Entity<Composition>()
                .HasOne(c => c.EnsembleType)         // A Composition has one EnsembleType
                .WithMany(e => e.Compositions)        // An EnsembleType has many Compositions
                .HasForeignKey(c => c.EnsembleTypeID) // Foreign key: EnsembleTypeID
                .OnDelete(DeleteBehavior.Restrict);   // Prevent delete if compositions exist

            //--- GENRE RELATIONSHIPS ---//

            // 1 Genre → Many Compositions
            modelBuilder.Entity<Composition>()
                .HasOne(c => c.Genre)                 // A Composition has one Genre
                .WithMany(g => g.Compositions)        // A Genre has many Compositions
                .HasForeignKey(c => c.GenreID)        // Foreign key: GenreID
                .OnDelete(DeleteBehavior.Restrict);   // Prevent delete if compositions exist

            //--- RECORDING RELATIONSHIPS ---//

            // 1 Composition → Many Recordings
            modelBuilder.Entity<Recording>()
                .HasOne(r => r.Composition)           // A Recording has one Composition
                .WithMany(c => c.Recordings)          // A Composition has many Recordings
                .HasForeignKey(r => r.CompositionID)  // Foreign key: CompositionID
                .OnDelete(DeleteBehavior.Cascade);    // Delete recordings if composition is deleted

            //--- LIBRARY INVENTORY RELATIONSHIPS ---//

            // 1 Recording → Many LibraryInventory items
            modelBuilder.Entity<LibraryInventory>()
                .HasOne(li => li.Recording)           // An Inventory item has one Recording
                .WithMany(r => r.LibraryInventories)  // A Recording has many Inventory items
                .HasForeignKey(li => li.RecordingID) // Foreign key: RecordingID
                .OnDelete(DeleteBehavior.Cascade);   // Delete inventory if recording is deleted

            
        }
    }
}