using System.Collections.Generic;
using System.Net;
using SpeakEasy.GitHub.Models;
using Authorization = SpeakEasy.GitHub.Models.Authorization;

namespace SpeakEasy.GitHub
{
    public class Authorizations
    {
        private readonly IHttpClient client;

        public Authorizations(IHttpClient client)
        {
            this.client = client;
        }

        public IEnumerable<Authorization> List()
        {
            return client.Get("authorizations").OnOk().As<List<Authorization>>();
        }

        public Authorization Get(long id)
        {
            return client.Get("authorizations/:id", new { id }).OnOk().As<Authorization>();
        }

        public Authorization Create(SaveAuthorization authorization)
        {
            return client.Post(authorization, "authorizations").On(HttpStatusCode.Created).As<Authorization>();
        }

        public Authorization Edit(long id, EditAuthorization authorization)
        {
            return client.Patch(authorization, "authorizations/:id", new { id }).OnOk().As<Authorization>();
        }

        public bool Delete(long id)
        {
            return client.Delete("authorizations/:id", new { id }).Is(HttpStatusCode.NoContent);
        }
    }
}