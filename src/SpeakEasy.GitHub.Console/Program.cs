using System.Linq;

namespace SpeakEasy.GitHub.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = GitHubApi.CreateAnonymous();

            var header = api.Repositories.GetForUser("jonnii").Single(r => r.Name == "SpeakEasy");
            System.Console.WriteLine(header);

            var repository = api.Repositories.Get("jonnii", "SpeakEasy");
            System.Console.WriteLine(repository);

            System.Console.ReadLine();
        }
    }
}
