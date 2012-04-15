namespace SpeakEasy.GitHub.Models
{
    public class GistFile
    {
        public long Size { get; set; }

        public string FileName { get; set; }

        public string RawUrl { get; set; }

        public string Content { get; set; }
    }
}