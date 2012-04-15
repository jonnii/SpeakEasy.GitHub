using System;
using System.Collections.Generic;
using System.Net;
using SpeakEasy.Authenticators;
using SpeakEasy.GitHub.Models;
using SpeakEasy.Serializers;

namespace SpeakEasy.GitHub
{
    public class GitHubApi
    {
        public static GitHubApi CreateAnonymous()
        {
            var settings = HttpClientSettings.Default;
            settings.Configure<JsonDotNetSerializer>(j => j.ConfigureSettings(s => s.ContractResolver = new GithubContractResolver()));
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
        }

        public event EventHandler<EventArgs> ReachingRequestLimit;

        public IEnumerable<RepositoryHeader> MyRepositories()
        {
            return client.Get("user/repos").OnOk()
                .As<List<RepositoryHeader>>();
        }

        public IEnumerable<RepositoryHeader> GetRepositoriesForUser(string user)
        {
            return client.Get("users/:user/repos", new { user }).OnOk()
                .As<List<RepositoryHeader>>();
        }

        public IEnumerable<RepositoryHeader> GetRepositoriesForOrganisation(string org)
        {
            return client.Get("users/:org/repos", new { org }).OnOk()
                .As<List<RepositoryHeader>>();
        }

        public RepositoryHeader Create(NewRepository repository)
        {
            return client.Post(repository, "user/repos").On(HttpStatusCode.Created).As<RepositoryHeader>();
        }

        public RepositoryHeader Create(string org, NewRepository repository)
        {
            return client.Post(repository, "orgs/:org/repos", new { org }).On(HttpStatusCode.Created).As<RepositoryHeader>();
        }

        public Repository GetRepository(string user, string repo)
        {
            return client.Get("repos/:user/:repo", new { user, repo }).OnOk()
                .As<Repository>();
        }
    }
}
