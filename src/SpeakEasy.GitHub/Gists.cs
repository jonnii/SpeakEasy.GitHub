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

        public IEnumerable<GistHeader> GetAll(int page = 1, int perPage = 30)
        {
            return client.Get("gists", new { page, per_page = perPage }).OnOk().As<List<GistHeader>>();
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

        public Gist Create(SaveGist saveGist)
        {
            return client.Post(saveGist, "gists").On(HttpStatusCode.Created).As<Gist>();
        }

        public Gist Edit(long id, SaveGist updatedGist)
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

        public IEnumerable<Comment> GetComments(long id)
        {
            return client.Get("gists/:id/comments", new { id }).OnOk().As<List<Comment>>();
        }

        public Comment GetComment(long id)
        {
            return client.Get("gists/comments/:id", new { id }).OnOk().As<Comment>();
        }

        public Comment Create(long id, SaveComment comment)
        {
            return client.Post(comment, "gists/:id/comments", new { id }).On(HttpStatusCode.Created).As<Comment>();
        }

        public Comment Edit(long id, SaveComment comment)
        {
            return client.Patch(comment, "gists/comments/:id", new { id }).OnOk().As<Comment>();
        }

        public bool DeleteComment(long id)
        {
            return client.Delete("gists/comments/:id", new { id }).Is(HttpStatusCode.NoContent);
        }
    }
}