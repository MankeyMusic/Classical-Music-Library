namespace Classical_Music_Library_Web_App.ViewModels
{
    // For inventory summary reports
    public class InventoryReportViewModel
    {
        public string Format { get; set; }      // CD, Vinyl, etc.
        public int TotalCount { get; set; }     // Total items
        public int AvailableCount { get; set; } // Available items
    }
}