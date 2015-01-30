namespace Thinktecture.IdentityServer3.RavenDB.Configuration
{
    using IdentityServer.Core.Configuration;
    using IdentityServer.Core.Models;
    using IdentityServer.Core.Services;
    using Raven.Client;
    using Stores;

    public static class FactoryConfiguration
    {
        public static void ConfigureRavenSession(this IdentityServerServiceFactory factory, RavenServiceOptions options)
        {
            factory.Register(new Registration<IAsyncDocumentSession>(resolver => options.Store.OpenAsyncSession(options.DatabaseName)));
        }

        public static void ConfigureClient(this IdentityServerServiceFactory factory, RavenServiceOptions options)
        {
            options.Store.Conventions.RegisterIdConvention<Client>(
                (dbname, commands, client) => options.Store.Conventions.FindTypeTagName(typeof(Client)) + "/" + client.ClientId);
            factory.Register(new Registration<IClientStore, ClientStore>());
        }
    }
}
