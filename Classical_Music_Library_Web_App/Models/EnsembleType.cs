using System.Collections.Generic;

namespace Classical_Music_Library_Web_App.Models
{
	public class EnsembleType
	{
		public int EnsembleTypeID { get; set; }
		public string TypeName { get; set; }
		public string Description { get; set; }

		public ICollection<Recording> Recordings { get; set; }
	}
}