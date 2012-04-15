using System.Collections.Generic;

namespace SpeakEasy.GitHub.Models
{
    public class NewGist
    {
        public NewGist()
        {
            Files = new Dictionary<string, NewFileContent>();
        }

        public string Description { get; set; }

        public bool Public { get; set; }

        public Dictionary<string, NewFileContent> Files { get; set; }
    }
}