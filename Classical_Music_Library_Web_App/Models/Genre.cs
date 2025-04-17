namespace Classical_Music_Library_Web_App.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string? GenreName { get; set; }

        public ICollection<Composition> Compositions { get; set; } = new List<Composition>();
        public ICollection<Recording> Recordings { get; set; } = new List<Recording>();
    }
}