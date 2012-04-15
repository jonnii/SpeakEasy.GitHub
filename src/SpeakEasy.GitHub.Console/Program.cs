using SpeakEasy.GitHub.Models;

namespace SpeakEasy.GitHub.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = GitHubApi.CreateAnonymous();

            var newGist = new NewGist
                              {
                                  Description = "test gist",
                                  Public = true,
                              };

            newGist.Files.Add("awesome.txt", new NewFileContent { Content = "uploaded from speakeasy C# library, http://github.com/jonnii/speakeasy" });

            var gist = api.Gists.Create(newGist);

            System.Console.WriteLine(gist.Id);
            System.Console.WriteLine(gist.Url);

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
