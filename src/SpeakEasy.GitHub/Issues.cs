using System.Collections.Generic;
using System.Net;
using SpeakEasy.GitHub.Models;

namespace SpeakEasy.GitHub
{
    public class Issues
    {
        private readonly IHttpClient client;

        public Issues(IHttpClient client)
        {
            this.client = client;
        }

        public IEnumerable<Issue> GetMine()
        {
            return client.Get("issues").OnOk().As<List<Issue>>();
        }

        public IEnumerable<Issue> Get(string user, string repo)
        {
            return client.Get("repos/:user/:repo/issues", new { user, repo }).OnOk().As<List<Issue>>();
        }

        public Issue Get(string user, string repo, long number)
        {
            return client.Get("repos/:user/:repo/issues/:number", new { user, repo, number }).OnOk().As<Issue>();
        }

        public Issue Create(string user, string repo, NewIssue issue)
        {
            return client.Post(issue, "repos/:user/:repo/issues", new { user, repo }).On(HttpStatusCode.Created).As<Issue>();
        }

        public Issue Edit(string user, string repo, long number, NewIssue issue)
        {
            return client.Post(issue, "repos/:user/:repo/issues/:number", new { user, repo, number }).OnOk().As<Issue>();
        }
    }
}