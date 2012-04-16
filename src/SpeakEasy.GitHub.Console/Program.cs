namespace SpeakEasy.GitHub.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = GitHubApi.CreateAnonymous();

            var user = api.Users.Get();

            System.Console.WriteLine(user.Id);
            System.Console.WriteLine(user.Name);

            System.Console.ReadLine();
        }
    }
}
