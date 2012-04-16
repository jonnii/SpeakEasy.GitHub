using System.Collections.Generic;
using System.Net;
using SpeakEasy.GitHub.Models;

namespace SpeakEasy.GitHub
{
    public class Keys
    {
        private readonly IHttpClient client;

        public Keys(IHttpClient client)
        {
            this.client = client;
        }

        public IEnumerable<PublicKey> List()
        {
            return client.Get("user/keys").OnOk().As<List<PublicKey>>();
        }

        public PublicKey Get(long id)
        {
            return client.Get("user/keys/:id", new { id }).OnOk().As<PublicKey>();
        }

        public PublicKey Save(SaveKey key)
        {
            return client.Post(key, "user/keys").On(HttpStatusCode.Created).As<PublicKey>();
        }

        public PublicKey Update(long id, SaveKey key)
        {
            return client.Patch(key, "user/keys/:id", new { id }).OnOk().As<PublicKey>();
        }

        public bool Delete(long id)
        {
            return client.Delete("user/keys/:id", new { id }).Is(HttpStatusCode.NoContent);
        }
    }
}