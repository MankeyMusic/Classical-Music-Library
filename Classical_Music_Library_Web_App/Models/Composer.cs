using System.Collections.Generic; //This is necessary for the Compositions property.
namespace Classical_Music_Library_Web_App.Models
{
	public class Composer
	{
		public int ComposerID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Era { get; set; }
		public string Nationality { get; set; }
		public int? BirthYear { get; set; }

		public ICollection<Composition> Compositions { get; set; } // Navigation property
	}
}