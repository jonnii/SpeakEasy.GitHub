namespace SpeakEasy.GitHub.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = GitHubApi.CreateAnonymous();

            var issues = api.Issues.Get("jonnii", "speakeasy");

            foreach(var issue in issues)
            {
                System.Console.WriteLine(issue.Body);
            }



            System.Console.ReadLine();
        }
    }
}
