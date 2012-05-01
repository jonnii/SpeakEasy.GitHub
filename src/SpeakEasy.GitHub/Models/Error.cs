namespace SpeakEasy.GitHub.Models
{
    public class Error
    {
        public string Message { get; set; }

        public ValidationError[] Errors { get; set; }
    }
}
