namespace Classical_Music_Library_Web_App.Models
{
    public class MusicDbContext
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
