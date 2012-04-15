using System.Collections.Generic;
using SpeakEasy.GitHub.Models;

namespace SpeakEasy.GitHub
{
    public class Gists
    {
        private readonly IHttpClient client;

        public Gists(IHttpClient client)
        {
            this.client = client;
        }

        public IEnumerable<GistHeader> GetForUser(string user)
        {
            return client.Get("users/:user/gists", new { user }).OnOk().As<List<GistHeader>>();
        }

        public IEnumerable<GistHeader> GetAll()
        {
            return client.Get("gists").OnOk().As<List<GistHeader>>();
        }

        public IEnumerable<GistHeader> GetPublic()
        {
            return client.Get("gists/public").OnOk().As<List<GistHeader>>();
        }

        public IEnumerable<GistHeader> GetStarred()
        {
            return client.Get("gists/starred").OnOk().As<List<GistHeader>>();
        }

        public Gist Get(long id)
        {
            return client.Get("gists/:id", new { id }).OnOk().As<Gist>();
        }
    }
}