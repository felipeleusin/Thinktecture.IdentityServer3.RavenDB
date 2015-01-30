namespace Thinktecture.IdentityServer3.RavenDB.Tests.Stores.Client
{
    using System.Threading.Tasks;
    using Configuration;
    using Helpers;
    using RavenDB.Stores;
    using Shouldly;
    using Xunit;

    public class ClientStoreTests : BaseTest
    {
        public ClientStoreTests()
        {
            Factory.ConfigureClient(RavenOptions);
            TestClients.Get().LoadTo(Store);
        }

        [Fact]
        public async Task CanLoadClientById()
        {
            var store = new ClientStore(Session);
            var client = await store.FindClientByIdAsync("codeclient");

            client.ShouldNotBe(null);
        }
    }
}
