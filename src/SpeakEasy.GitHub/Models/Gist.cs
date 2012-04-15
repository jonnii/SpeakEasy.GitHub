using System.Collections.Generic;

namespace SpeakEasy.GitHub.Models
{
    public class Gist : GistHeader
    {
        public List<Fork> Forks { get; set; }

        public List<History> History { get; set; }
    }
}