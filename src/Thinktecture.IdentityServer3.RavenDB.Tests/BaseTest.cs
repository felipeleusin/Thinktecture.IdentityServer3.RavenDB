namespace Thinktecture.IdentityServer3.RavenDB.Tests
{
    using Configuration;
    using IdentityServer.Core.Configuration;
    using Raven.Client;
    using Raven.Database.Storage;
    using Raven.Tests.Helpers;

    public abstract class BaseTest : RavenTestBase
    {
        protected readonly RavenServiceOptions RavenOptions;
        protected readonly IdentityServerServiceFactory Factory;
        protected readonly IDocumentStore Store;

        protected BaseTest()
        {
            Store = NewDocumentStore();
            RavenOptions = new RavenServiceOptions(Store);
            Factory = new IdentityServerServiceFactory();
            Factory.ConfigureRavenSession(RavenOptions);
        }
    }
}
