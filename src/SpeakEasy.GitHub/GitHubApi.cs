﻿using System;
using System.Net;
using SpeakEasy.Authenticators;
using SpeakEasy.GitHub.Models;
using SpeakEasy.Loggers;
using SpeakEasy.Serializers;

namespace SpeakEasy.GitHub
{
    public class GitHubApi
    {
        public static GitHubApi CreateAnonymous()
        {
            var settings = CreateDefaultSettings();
            settings.Logger = new ConsoleLogger();

            var client = HttpClient.Create("https://api.github.com", settings);

            return new GitHubApi(client);
        }

        public static GitHubApi CreateWithBasicAuthentication(string username, string password)
        {
            var settings = CreateDefaultSettings();
            settings.Authenticator = new BasicAuthenticator(username, password);

            var client = HttpClient.Create("https://api.github.com", settings);

            return new GitHubApi(client);
        }

        private static HttpClientSettings CreateDefaultSettings()
        {
            var settings = HttpClientSettings.Default;
            settings.Configure<JsonDotNetSerializer>(j => j.ConfigureSettings(s => s.ContractResolver = new GithubContractResolver()));
            settings.NamingConvention = new UnderscoreNamingConvention();

            return settings;
        }

        private readonly IHttpClient client;

        public GitHubApi(IHttpClient client)
        {
            this.client = client;

            client.BeforeRequest += ClientOnBeforeRequest;
            client.AfterRequest += ClientOnAfterRequest;

            Repositories = new Repositories(client);
            Gists = new Gists(client);
            Issues = new Issues(client);
            Milestones = new Milestones(client);
            Labels = new Labels(client);
            Users = new Users(client);
            Authorizations = new Authorizations(client);
            Keys = new Keys(client);
        }

        public Authorizations Authorizations { get; private set; }

        public Keys Keys { get; private set; }

        public event EventHandler<EventArgs> ReachingRequestLimit;

        public Repositories Repositories { get; private set; }

        public Gists Gists { get; private set; }

        public Issues Issues { get; private set; }

        public Milestones Milestones { get; private set; }

        public Labels Labels { get; private set; }

        public Users Users { get; private set; }

        private void ClientOnBeforeRequest(object sender, BeforeRequestEventArgs e)
        {

        }

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


            args.Response.On(HttpStatusCode.BadRequest, (Error error) =>
            {
                throw new ValidationException(error);
            });
        }
    }
}
