namespace Classical_Music_Library_Web_App.Models
{
    // Represents musical ensemble types (e.g., Orchestra, String Quartet)
    public class EnsembleType
    {
        public int EnsembleTypeID { get; set; }       // Primary key
        [Required]
        public string TypeName { get; set; }          // e.g., "Symphony Orchestra"
        public string? Description { get; set; }      // Optional details

        // Navigation property (1 ensemble type → many compositions)
        public ICollection<Composition>? Compositions { get; set; }
    }
}