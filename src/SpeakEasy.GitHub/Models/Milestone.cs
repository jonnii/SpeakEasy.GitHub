namespace SpeakEasy.GitHub.Models
{
    public class Milestone
    {
        public string Url { get; set; }
        public int Number { get; set; }
        public string State { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User Creator { get; set; }
        public int OpenIssues { get; set; }
        public int ClosedIssues { get; set; }
        public string CreatedAt { get; set; }
        public object DueOn { get; set; }
    }
}