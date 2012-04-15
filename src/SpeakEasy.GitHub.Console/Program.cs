using System.Linq;

namespace SpeakEasy.GitHub.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = GitHubApi.CreateAnonymous();

            //var header = api.Repositories.GetForUser("jonnii").Single(r => r.Name == "SpeakEasy");
            //System.Console.WriteLine(header);

            //var repository = api.Repositories.Get("jonnii", "SpeakEasy");
            //System.Console.WriteLine(repository);

            //var gists = api.Gists.GetAll();
            //foreach (var gist in gists)
            //{
            //    System.Console.WriteLine(gist);
            //}

            //var fullGist = api.Gists.Get(gists.First().Id);

            //var additions = fullGist.History.First().ChangeStatus.Additions;
            //System.Console.WriteLine(additions);

            System.Console.ReadLine();
        }
    }
}
