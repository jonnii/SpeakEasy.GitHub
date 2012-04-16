namespace SpeakEasy.GitHub.Models
{
    public class EditAuthorization
    {
        public string[] Scopes { get; set; }

        public string[] AddScopes { get; set; }

        public string[] RemoveScopes { get; set; }

        public string Note { get; set; }

        public string NoteUrl { get; set; }
    }
}