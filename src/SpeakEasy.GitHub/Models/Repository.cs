namespace SpeakEasy.GitHub.Models
{
    public class Repository : RepositoryHeader
    {
        public Organization Organization { get; set; }

        public RepositoryHeader Parent { get; set; }

        public RepositoryHeader Source { get; set; }
    }
}