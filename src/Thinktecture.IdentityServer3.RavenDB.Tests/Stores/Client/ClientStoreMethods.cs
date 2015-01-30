namespace Thinktecture.IdentityServer3.RavenDB.Tests.Stores.Client
{
    using System.Threading.Tasks;
    using Configuration;
    using Helpers;
    using RavenDB.Stores;
    using Shouldly;
    using Xunit;

    public class ClientStoreMethods : BaseTest
    {
        public ClientStoreMethods()
        {
            Factory.ConfigureClient(RavenOptions);
            Clients.LoadTo(Store);
        }

        [Fact]
        public async Task CanLoadClientById()
        {
            using (var session = Store.OpenAsyncSession())
            {
                var store = new ClientStore(session);
                var client = await store.FindClientByIdAsync("codeclient");

                client.ShouldNotBe(null);
            }
        }
    }
}
