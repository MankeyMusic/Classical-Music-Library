namespace Classical_Music_Library_Web_App.Models
{
    public class Composition
    {
        public int CompositionID { get; set; }
        public string? Title { get; set; }
        public int ComposerID { get; set; }  // Non-nullable (required)
        public int? EnsembleTypeID { get; set; }  // Nullable (optional)
        public int? GenreID { get; set; }  // Nullable (optional)
        public int? YearComposed { get; set; }

        // Required relationship
        public Composer Composer { get; set; } = null!;  // Remove "?"

        // Optional relationships (keep "?")
        public EnsembleType? EnsembleType { get; set; }
        public Genre? Genre { get; set; }

        public ICollection<Recording> Recordings { get; set; } = new List<Recording>();
    }
}