namespace SpeakEasy.GitHub.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = GitHubApi.CreateAnonymous();

            var issues = api.Issues.List("jonnii", "speakeasy", state: "closed");

            foreach (var issue in issues)
            {
                System.Console.WriteLine(issue.Title);
            }

            System.Console.ReadLine();
        }
    }
}
