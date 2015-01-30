namespace Thinktecture.IdentityServer3.RavenDB
{
    using Raven.Client;

    public class RavenServiceOptions
    {
        public RavenServiceOptions(IDocumentStore store, string databaseName=null)
        {
            Store = store;
            DatabaseName = databaseName;
        }

        public string DatabaseName { get; private set; }

        public IDocumentStore Store { get; private set; }
    }
}
