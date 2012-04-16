using System.Collections.Generic;
using System.Net;
using SpeakEasy.GitHub.Models;

namespace SpeakEasy.GitHub
{
    public class Labels
    {
        private readonly IHttpClient client;

        public Labels(IHttpClient client)
        {
            this.client = client;
        }

        public IEnumerable<Label> List(string user, string repo)
        {
            return client.Get("repos/:user/:repo/labels", new { user, repo }).OnOk().As<List<Label>>();
        }

        public IEnumerable<Label> List(string user, string repo, long number)
        {
            return client.Get("repos/:user/:repo/issues/:number/labels", new { user, repo, number }).OnOk().As<List<Label>>();
        }

        public Label Get(string user, string repo, string name)
        {
            return client.Get("repos/:user/:repo/labels/:name", new { user, repo, name }).OnOk().As<Label>();
        }

        public Label Create(string user, string repo, SaveLabel label)
        {
            return client.Post(label, "repos/:user/:repo/labels", new { user, repo }).On(HttpStatusCode.Created).As<Label>();
        }

        public Label Edit(string user, string repo, SaveLabel label)
        {
            return client.Patch(label, "repos/:user/:repo/labels", new { user, repo }).OnOk().As<Label>();
        }

        public bool Delete(string user, string repo, string name)
        {
            return client.Delete("repos/:user/:repo/labels/:name", new { user, repo, name }).Is(HttpStatusCode.NoContent);
        }
    }
}