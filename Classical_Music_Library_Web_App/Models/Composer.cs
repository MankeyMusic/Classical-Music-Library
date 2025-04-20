namespace Classical_Music_Library_Web_App.Models
{
    // Represents a composer (e.g., Beethoven, Mozart)
    public class Composer
    {
        public int ComposerID { get; set; }          // Primary key (auto-increment)
        public string? FirstName { get; set; }        // Optional first name
        [Required]
        public string LastName { get; set; }          // Required last name
        public string? Era { get; set; }              // Baroque/Classical/Romantic
        public string? Nationality { get; set; }      // e.g., "German", "Austrian"
        public int? BirthYear { get; set; }           // Nullable (unknown dates)
        public int? DeathYear { get; set; }

        // Navigation property (1 composer → many compositions)
        public ICollection<Composition>? Compositions { get; set; }
    }
}