namespace SpeakEasy.GitHub.Models
{
    public class Fork
    {
        public UserHeader User { get; set; }

        public string Url { get; set; }

        public string CreatedAt { get; set; }
    }
}