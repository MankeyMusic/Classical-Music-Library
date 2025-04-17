namespace Classical_Music_Library_Web_App.Models
{
    public class Composition
    {
        public int CompositionID { get; set; }
        public string? Title { get; set; }
        public int ComposerID { get; set; }
        public int? EnsembleTypeID { get; set; }
        public int? GenreID { get; set; }
        public int? YearComposed { get; set; }

        public Composer? Composer { get; set; }
        public EnsembleType? EnsembleType { get; set; }
        public Genre? Genre { get; set; }
        public ICollection<Recording> Recordings { get; set; } = new List<Recording>();
    }
}