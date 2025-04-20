namespace Classical_Music_Library_Web_App.Models
{
    // Represents physical/digital copies in the library
    public class LibraryInventory
    {
        public int LibraryInventoryID { get; set; }   // Primary key
        [Required]
        public string Format { get; set; }            // e.g., "CD", "Vinyl", "MP3"
        public string Status { get; set; } = "Available"; // Default: Available/CheckedOut/Lost
        public string? Location { get; set; }         // e.g., "Shelf A-12"

        // Foreign key
        public int RecordingID { get; set; }

        // Navigation property
        public Recording? Recording { get; set; }     // Linked recording
    }
}