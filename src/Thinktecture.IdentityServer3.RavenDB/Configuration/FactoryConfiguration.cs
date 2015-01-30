namespace Thinktecture.IdentityServer3.RavenDB.Configuration
{
    using IdentityServer.Core.Configuration;
    using IdentityServer.Core.Models;
    using IdentityServer.Core.Services;
    using Raven.Client;
    using Raven.Client.Indexes;
    using Stores;

    public static class FactoryConfiguration
    {
        public static void ConfigureRavenSession(this IdentityServerServiceFactory factory, RavenServiceOptions options)
        {
            IndexCreation.CreateIndexes(typeof(RavenServiceOptions).Assembly, options.Store);
            factory.Register(new Registration<IAsyncDocumentSession>(resolver => options.Store.OpenAsyncSession(options.DatabaseName)));
        }

        public static void ConfigureClient(this IdentityServerServiceFactory factory, RavenServiceOptions options)
        {
            options.Store.Conventions.RegisterIdConvention<Client>(
                (dbname, commands, client) => options.Store.Conventions.FindTypeTagName(typeof(Client)) + "/" + client.ClientId);
            factory.Register(new Registration<IClientStore, ClientStore>());
        }

        public static void ConfigureScope(this IdentityServerServiceFactory factory, RavenServiceOptions options)
        {
            options.Store.Conventions.RegisterIdConvention<Scope>(
                (dbname, commands, scope) => options.Store.Conventions.FindTypeTagName(typeof(Scope)) + "/" + scope.Name);
            factory.Register(new Registration<IScopeStore, ScopeStore>());
        }

        
    }
}
