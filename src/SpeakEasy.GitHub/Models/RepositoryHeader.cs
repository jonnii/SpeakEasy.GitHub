using System;

namespace SpeakEasy.GitHub.Models
{
    public class RepositoryHeader
    {
        public int OpenIssues { get; set; }

        public string GitUrl { get; set; }

        public string CloneUrl { get; set; }

        public DateTime PushedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public string MirrorUrl { get; set; }

        public string Description { get; set; }

        public bool HasDownloads { get; set; }

        public int Watchers { get; set; }

        public string Url { get; set; }

        public bool Fork { get; set; }

        public string HtmlUrl { get; set; }

        public long Size { get; set; }

        public string Homepage { get; set; }

        public bool Private { get; set; }

        public bool HasWiki { get; set; }

        public bool HasIssues { get; set; }

        public DateTime UpdatedAt { get; set; }

        public UserHeader Owner { get; set; }

        public string Name { get; set; }

        public int Forks { get; set; }

        public string SvnUrl { get; set; }

        public string SshUrl { get; set; }

        public long Id { get; set; }

        public string MasterBranch { get; set; }

        public string Language { get; set; }

        public override string ToString()
        {
            return string.Format("[Repository Name={0}, Url={1}, Description={2}]", Name, Url, Description);
        }
    }
}