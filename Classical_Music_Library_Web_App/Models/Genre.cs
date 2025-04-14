using System.Collections.Generic;

namespace Classical_Music_Library_Web_App.Models
{
    public class Genre
    {
	    public int GenreID { get; set; }
        public string GenreName { get; set; }

        public ICollection<Recording> Recordings { get; set; }

    }
}
