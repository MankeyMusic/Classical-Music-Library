using Classical_Music_Library_Web_App.Data;

namespace Classical_Music_Library_Web_App.Models
{
    public class Recording
    {
        public int RecordingID { get; set; }
        public int CompositionID { get; set; }
        public int? EnsembleTypeID { get; set; }
        public int? GenreID { get; set; }
        public string? EnsembleName { get; set; }
        public string? Soloist { get; set; }
        public int ReleaseYear { get; set; }

        public Composition? Composition { get; set; }
        public EnsembleType? EnsembleType { get; set; }
        public Genre? Genre { get; set; }
        public ICollection<LibraryInventory> LibraryInventories { get; set; } = new List<LibraryInventory>();
    }
}