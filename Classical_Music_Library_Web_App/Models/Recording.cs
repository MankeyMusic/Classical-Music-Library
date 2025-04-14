using System.Collections.Generic;

namespace Classical_Music_Library_Web_App.Models
{
	public class Recording
	{
		public int RecordingID { get; set; }
		public int CompositionID { get; set; }
		public string EnsembleName { get; set; }
		public string Soloist {get; set; }
		public int ReleaseYear { get; set; }

		public Composition Composition { get; set; }
		public ICollection<LibraryInventory> LibraryInventories { get; set; }
	}
}