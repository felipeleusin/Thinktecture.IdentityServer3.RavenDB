namespace Thinktecture.IdentityServer3.RavenDB.Tests
{
    using System;
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
        private readonly Lazy<IAsyncDocumentSession> session;

        protected IAsyncDocumentSession Session
        {
            get { return session.Value; }
        }

        protected BaseTest()
        {
            Store = NewDocumentStore();
            RavenOptions = new RavenServiceOptions(Store);
            Factory = new IdentityServerServiceFactory();
            Factory.ConfigureRavenSession(RavenOptions);
            session = new Lazy<IAsyncDocumentSession>(() => Store.OpenAsyncSession());
        }

        public override void Dispose()
        {
            if (Session != null)
            {
                Session.Dispose();
            }

            base.Dispose();
        }
    }
}
