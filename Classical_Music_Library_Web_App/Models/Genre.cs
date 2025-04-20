namespace Classical_Music_Library_Web_App.Models
{
    // Represents music genres (e.g., Symphony, Concerto)
    public class Genre
    {
        public int GenreID { get; set; }             // Primary key
        [Required]
        public string GenreName { get; set; }        // e.g., "Opera", "Sonata"

        // Navigation property (1 genre → many compositions)
        public ICollection<Composition>? Compositions { get; set; }
    }
}