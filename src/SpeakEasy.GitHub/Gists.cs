using System.Collections.Generic;
using System.Net;
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

        public Gist Create(NewGist newGist)
        {
            return client.Post(newGist, "gists").On(HttpStatusCode.Created).As<Gist>();
        }

        public Gist Edit(long id, NewGist updatedGist)
        {
            return client.Patch(updatedGist, "gists/:id", id).OnOk().As<Gist>();
        }

        public bool Star(long id)
        {
            return client.Put("gists/:id/star", new { id }).Is(HttpStatusCode.NoContent);
        }

        public bool Unstar(long id)
        {
            return client.Delete("gists/:id/star", new { id }).Is(HttpStatusCode.NoContent);
        }

        public bool IsStarred(long id)
        {
            var response = client.Get("gists/:id/star", new { id });

            if (response.Is(HttpStatusCode.NotFound))
            {
                return false;
            }

            response.On(HttpStatusCode.NoContent);

            return true;
        }

        public GistHeader Fork(long id)
        {
            return client.Post("gists/:id/fork", new { id }).On(HttpStatusCode.Created).As<GistHeader>();
        }

        public bool Delete(long id)
        {
            return client.Delete("gists/:id", new { id }).Is(HttpStatusCode.NoContent);
        }
    }
}