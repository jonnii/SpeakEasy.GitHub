using System.Collections.Generic;
using System.Net;
using SpeakEasy.GitHub.Models;

namespace SpeakEasy.GitHub
{
    public class Milestones
    {
        private readonly IHttpClient client;

        public Milestones(IHttpClient client)
        {
            this.client = client;
        }

        public IEnumerable<Milestone> List(string user, string repo)
        {
            return client.Get("repos/:user/:repo/milestones", new { user, repo }).OnOk().As<List<Milestone>>();
        }

        public Milestone Get(string user, string repo, long number)
        {
            return client.Get("repos/:user/:repo/milestones/:number", new { user, repo, number }).OnOk().As<Milestone>();
        }

        public Milestone Create(string user, string repo, SaveMilestone milestone)
        {
            return client.Post(milestone, "repos/:user/:repo/milestones/:number", new { user, repo }).On(HttpStatusCode.Created).As<Milestone>();
        }

        public Milestone Edit(string user, string repo, long number, SaveMilestone milestone)
        {
            return client.Patch(milestone, "repos/:user/:repo/milestones/:number", new { user, repo }).OnOk().As<Milestone>();
        }

        public bool Delete(string user, string repo, long number)
        {
            return client.Delete("repos/:user/:repo/milestones/:number", new { user, repo, number }).Is(HttpStatusCode.NoContent);
        }
    }
}