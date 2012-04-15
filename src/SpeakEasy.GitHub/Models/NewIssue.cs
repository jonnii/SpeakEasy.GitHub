namespace SpeakEasy.GitHub.Models
{
    public class NewIssue
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string Asignee { get; set; }

        public int Milestone { get; set; }

        public string[] Labels { get; set; }
    }
}