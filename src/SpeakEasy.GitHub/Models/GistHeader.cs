using System;
using System.Collections.Generic;

namespace SpeakEasy.GitHub.Models
{
    public class GistHeader
    {
        public string Url { get; set; }

        public long Id { get; set; }

        public string Description { get; set; }

        public bool Public { get; set; }

        public User User { get; set; }

        public Dictionary<string, GistFile> Files { get; set; }

        public int Comments { get; set; }

        public string HtmlUrl { get; set; }

        public string GitPullUrl { get; set; }

        public string GitPushUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return string.Format("[GistHeader Id={0}, HtmlUrl={1}]", Id, HtmlUrl);
        }
    }
}
