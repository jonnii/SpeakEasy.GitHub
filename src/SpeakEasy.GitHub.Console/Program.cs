namespace SpeakEasy.GitHub.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = new GitHubApi();

            var repositories = api.GetRepositoriesForUser("jonnii");

            foreach (var repository in repositories)
            {
                System.Console.WriteLine(repository);
            }

            System.Console.ReadLine();
        }
    }
}
