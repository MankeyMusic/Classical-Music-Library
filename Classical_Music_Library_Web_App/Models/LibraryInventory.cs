namespace Classical_Music_Library_Web_App.Models
{
	public class LibraryInventory
	{
		public int LibraryInventoryID { get; set; }
		public int RecordingID { get; set; }
		public string Format { get; set; }
		public string Status { get; set; }
		public string Location { get; set; }

		public Recording Recording { get; set; }
	}
}