namespace Classical_Music_Library_Web_App.ViewModels
{
    // Custom shape for the "Available Recordings" query
    public class AvailableRecordingViewModel
    {
        public string ComposerName { get; set; }  // Combined first + last name
        public string WorkTitle { get; set; }     // Composition title
        public string Format { get; set; }        // CD, Vinyl, Digital, etc.
        public string Location { get; set; }      // Shelf location in library
    }
}