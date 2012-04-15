using System;
using SpeakEasy.Authenticators;
using SpeakEasy.Loggers;
using SpeakEasy.Serializers;

namespace SpeakEasy.GitHub
{
    public class GitHubApi
    {
        public static GitHubApi CreateAnonymous()
        {
            var settings = HttpClientSettings.Default;

            settings.Configure<JsonDotNetSerializer>(j => j.ConfigureSettings(s => s.ContractResolver = new GithubContractResolver()));
            settings.Logger = new ConsoleLogger();

            var client = HttpClient.Create("https://api.github.com", settings);

            return new GitHubApi(client);
        }

        public static GitHubApi CreateWithBasicAuthentication(string username, string password)
        {
            var settings = HttpClientSettings.Default;
            settings.Configure<JsonDotNetSerializer>(j => j.ConfigureSettings(s => s.ContractResolver = new GithubContractResolver()));
            settings.Authenticator = new BasicAuthenticator(username, password);

            var client = HttpClient.Create("https://api.github.com", settings);

            return new GitHubApi(client);
        }

        private readonly IHttpClient client;

        public GitHubApi(IHttpClient client)
        {
            this.client = client;

            client.AfterRequest += ClientOnAfterRequest;

            Repositories = new Repositories(client);
            Gists = new Gists(client);
            Issues = new Issues(client);
            Milestones = new Milestones(client);
        }

        public event EventHandler<EventArgs> ReachingRequestLimit;

        public Repositories Repositories { get; private set; }

        public Gists Gists { get; private set; }

        public Issues Issues { get; private set; }

        public Milestones Milestones { get; private set; }

        private void ClientOnAfterRequest(object sender, AfterRequestEventArgs args)
        {
            var remaining = int.Parse(args.Response.GetHeaderValue("X-RateLimit-Remaining"));

            if (remaining >= 500)
            {
                return;
            }

            var handler = ReachingRequestLimit;
            if (handler != null)
            {
                ReachingRequestLimit(this, EventArgs.Empty);
            }
        }
    }
}
