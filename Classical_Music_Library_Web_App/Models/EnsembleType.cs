namespace Classical_Music_Library_Web_App.Models
{
    public class EnsembleType
    {
        public int EnsembleTypeID { get; set; }
        public string? TypeName { get; set; }
        public string? Description { get; set; }

        public ICollection<Composition> Compositions { get; set; } = new List<Composition>();
        public ICollection<Recording> Recordings { get; set; } = new List<Recording>();
    }
}