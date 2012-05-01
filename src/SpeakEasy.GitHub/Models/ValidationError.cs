namespace SpeakEasy.GitHub.Models
{
    public class ValidationError
    {
        public string Resource { get; set; }

        public string Field { get; set; }

        public string Code { get; set; }
    }
}