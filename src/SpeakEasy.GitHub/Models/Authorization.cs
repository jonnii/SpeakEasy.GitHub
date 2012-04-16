using System.Collections.Generic;

namespace SpeakEasy.GitHub.Models
{
    public class Authorization
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public List<string> Scopes { get; set; }
        public string Token { get; set; }
        public App App { get; set; }
        public string Note { get; set; }
        public string NoteUrl { get; set; }
        public string UpdatedAt { get; set; }
        public string CreatedAt { get; set; }
    }
}
