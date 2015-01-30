namespace Thinktecture.IdentityServer3.RavenDB.Stores
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IdentityServer.Core.Models;
    using IdentityServer.Core.Services;
    using Indexes;
    using Raven.Client;
    using Raven.Client.Linq;

    public class ScopeStore : IScopeStore
    {
        private readonly IAsyncDocumentSession session;

        public ScopeStore(IAsyncDocumentSession session)
        {
            this.session = session;
        }

        public async Task<IEnumerable<Scope>> FindScopesAsync(IEnumerable<string> scopeNames)
        {
            var query = session.Query<Scope, Scopes_Index>();

            if (scopeNames != null)
            {
                query.Where(x => x.Name.In(scopeNames));
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Scope>> GetScopesAsync(bool publicOnly = true)
        {
            var query = session.Query<Scope, Scopes_Index>();

            if (publicOnly)
            {
                query.Where(x => x.ShowInDiscoveryDocument);
            }

            return await query.ToListAsync();
        }
    }
}