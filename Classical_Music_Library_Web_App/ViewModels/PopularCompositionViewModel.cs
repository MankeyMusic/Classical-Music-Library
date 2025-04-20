namespace Classical_Music_Library_Web_App.ViewModels
{
    // Custom shape for "Popular Compositions" query
    public class PopularCompositionViewModel
    {
        public int CompositionId { get; set; }
        public string Title { get; set; }
        public string ComposerName { get; set; }
        public int RecordingCount { get; set; }  // How many recordings exist
    }
}