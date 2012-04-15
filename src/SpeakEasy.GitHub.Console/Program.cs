using System.Linq;

namespace SpeakEasy.GitHub.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = GitHubApi.CreateAnonymous();

            var header = api.GetRepositoriesForUser("jonnii").Single(r => r.Name == "SpeakEasy");
            System.Console.WriteLine(header);

            var repository = api.GetRepository("jonnii", "SpeakEasy");
            System.Console.WriteLine(repository);

            System.Console.ReadLine();
        }
    }
}
