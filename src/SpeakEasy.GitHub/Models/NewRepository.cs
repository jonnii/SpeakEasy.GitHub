namespace SpeakEasy.GitHub.Models
{
    public class NewRepository
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Homepage { get; set; }

        public bool Private { get; set; }

        public bool HasIssues { get; set; }

        public bool HasWiki { get; set; }

        public bool HasDownloads { get; set; }

        public long TeamId { get; set; }
    }
}