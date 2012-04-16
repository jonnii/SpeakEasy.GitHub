using System.Collections.Generic;

namespace SpeakEasy.GitHub.Models
{
    public class SaveGist
    {
        public SaveGist()
        {
            Files = new Dictionary<string, SaveFileContent>();
        }

        public string Description { get; set; }

        public bool Public { get; set; }

        public Dictionary<string, SaveFileContent> Files { get; set; }
    }
}