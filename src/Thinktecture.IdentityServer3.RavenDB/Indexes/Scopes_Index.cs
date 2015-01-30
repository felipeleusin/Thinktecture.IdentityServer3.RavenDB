namespace Thinktecture.IdentityServer3.RavenDB.Indexes
{
    using System.Linq;
    using IdentityServer.Core.Models;
    using Raven.Abstractions.Indexing;
    using Raven.Client.Indexes;

    public class Scopes_Index : AbstractIndexCreationTask<Scope>
    {
        public Scopes_Index()
        {
            Map = scopes =>
                from scope in scopes
                select new
                {
                    scope.Name,
                    scope.ShowInDiscoveryDocument
                };

            Index(x => x.Name, FieldIndexing.NotAnalyzed);
        }
    }
}
