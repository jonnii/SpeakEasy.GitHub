using System.Collections.Generic;
using SpeakEasy.GitHub.Models;
using SpeakEasy.Serializers;

namespace SpeakEasy.GitHub
{
    public class GitHubApi
    {
        private readonly IHttpClient client;

        public GitHubApi()
        {
            var settings = HttpClientSettings.Default;

            settings.Configure<JsonDotNetSerializer>(j => j.ConfigureSettings(s => s.ContractResolver = new GithubContractResolver()));

            client = HttpClient.Create("https://api.github.com", settings);
        }

        public IEnumerable<Repository> GetRepositoriesForUser(string user)
        {
            return client.Get("users/:user/repos", new { user }).OnOk()
                .As<List<Repository>>();
        }
    }
}
