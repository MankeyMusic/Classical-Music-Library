namespace Classical_Music_Library_Web_App.Models
{
    // Represents a musical work (e.g., Symphony No. 5)
    public class Composition
    {
        public int CompositionID { get; set; }        // Primary key
        [Required]
        public string Title { get; set; }             // e.g., "Moonlight Sonata"
        public int? YearComposed { get; set; }        // Nullable if unknown

        // Foreign keys
        public int ComposerID { get; set; }
        public int EnsembleTypeID { get; set; }
        public int GenreID { get; set; }

        // Navigation properties
        public Composer? Composer { get; set; }       // Linked composer
        public EnsembleType? EnsembleType { get; set; } // Linked ensemble
        public Genre? Genre { get; set; }             // Linked genre
        public ICollection<Recording>? Recordings { get; set; } // 1 work → many recordings
    }
}