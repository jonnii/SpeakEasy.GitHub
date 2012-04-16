using System.Collections.Generic;

namespace SpeakEasy.GitHub.Models
{
    public class Issue
    {
        public string Url { get; set; }
        public string HtmlUrl { get; set; }
        public long Number { get; set; }
        public string State { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public UserHeader User { get; set; }
        public List<Label> Labels { get; set; }
        public UserHeader Assignee { get; set; }
        public Milestone Milestone { get; set; }
        public int Comments { get; set; }
        public PullRequest PullRequest { get; set; }
        public object ClosedAt { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
