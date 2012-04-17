using System.Linq;

namespace SpeakEasy.GitHub.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = GitHubApi.CreateAnonymous();

            var gist = api.Gists.List(1, 50);

            System.Console.WriteLine(gist.Count());

            System.Console.ReadLine();
        }
    }
}
