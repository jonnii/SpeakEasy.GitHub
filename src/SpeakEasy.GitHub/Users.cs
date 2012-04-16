using SpeakEasy.GitHub.Models;

namespace SpeakEasy.GitHub
{
    public class Users
    {
        private readonly IHttpClient client;

        public Users(IHttpClient client)
        {
            this.client = client;
        }

        public AuthenticatedUser Get()
        {
            return client.Get("user").OnOk().As<AuthenticatedUser>();
        }

        public User Get(string user)
        {
            return client.Get("users/:user", new { user }).OnOk().As<User>();
        }

        public AuthenticatedUser Edit(SaveUser user)
        {
            return client.Patch(user, "user").OnOk().As<AuthenticatedUser>();
        }
    }
}