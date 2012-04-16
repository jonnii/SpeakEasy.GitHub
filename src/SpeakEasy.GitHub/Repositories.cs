using System.Collections.Generic;
using System.Net;
using SpeakEasy.GitHub.Models;

namespace SpeakEasy.GitHub
{
    public class Repositories
    {
        private readonly IHttpClient client;

        public Repositories(IHttpClient client)
        {
            this.client = client;
        }

        public IEnumerable<RepositoryHeader> GetMine()
        {
            return client.Get("user/repos").OnOk()
                .As<List<RepositoryHeader>>();
        }

        public Repository Get(string user, string repo)
        {
            return client.Get("repos/:user/:repo", new { user, repo }).OnOk()
                .As<Repository>();
        }

        public IEnumerable<RepositoryHeader> GetForUser(string user)
        {
            return client.Get("users/:user/repos", new { user }).OnOk()
                .As<List<RepositoryHeader>>();
        }

        public IEnumerable<RepositoryHeader> GetForOrganization(string org)
        {
            return client.Get("users/:org/repos", new { org }).OnOk()
                .As<List<RepositoryHeader>>();
        }

        public RepositoryHeader Create(SaveRepository repository)
        {
            return client.Post(repository, "user/repos").On(HttpStatusCode.Created).As<RepositoryHeader>();
        }

        public RepositoryHeader Create(string org, SaveRepository repository)
        {
            return client.Post(repository, "orgs/:org/repos", new { org }).On(HttpStatusCode.Created).As<RepositoryHeader>();
        }
    }
}