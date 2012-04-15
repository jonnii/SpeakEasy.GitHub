namespace SpeakEasy.GitHub.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = GitHubApi.CreateAnonymous();

            var issues = api.Labels.List("jonnii", "speakeasy");

            foreach (var issue in issues)
            {
                System.Console.WriteLine(issue.Name);
            }

            System.Console.ReadLine();
        }
    }
}
