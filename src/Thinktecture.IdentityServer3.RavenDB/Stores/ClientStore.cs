namespace Thinktecture.IdentityServer3.RavenDB.Stores
{
    using System.Threading.Tasks;
    using IdentityServer.Core.Models;
    using IdentityServer.Core.Services;
    using Raven.Client;

    public class ClientStore : IClientStore
    {
        private readonly IAsyncDocumentSession session;

        public ClientStore(IAsyncDocumentSession session)
        {
            this.session = session;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            return session.LoadWithTagId<Client>(clientId);
        }
    }
}
