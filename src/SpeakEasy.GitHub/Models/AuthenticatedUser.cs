namespace SpeakEasy.GitHub.Models
{
    public class AuthenticatedUser : User
    {
        public int TotalPrivateRepos { get; set; }
        public int OwnedPrivateRepos { get; set; }
        public int PrivateGists { get; set; }
        public int DiskUsage { get; set; }
        public int Collaborators { get; set; }
        public Plan Plan { get; set; }
    }
}