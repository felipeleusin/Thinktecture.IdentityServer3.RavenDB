namespace Thinktecture.IdentityServer3.RavenDB.Tests.Stores.Scopes
{
    using System.Linq;
    using System.Threading.Tasks;
    using Configuration;
    using Helpers;
    using RavenDB.Stores;
    using Shouldly;
    using Xunit;

    public class ScopeStoreTests : BaseTest
    {
        public ScopeStoreTests()
        {
            Factory.ConfigureScope(RavenOptions);
            TestScopes.Get().LoadTo(Store);
            WaitForIndexing(Store);
        }

        [Fact]
        public async Task CanFindExactName()
        {
            var store = new ScopeStore(Session);

            var result = (await store.FindScopesAsync(new[] {"read"})).ToArray();

            result.Count().ShouldBe(1);
            result.First().Name.ShouldBe("read");
        }

        [Fact]
        public async Task CanFindMultipleScopes()
        {
            var store = new ScopeStore(Session);

            var result = await store.FindScopesAsync(new[] { "read","write" });

            result.Count().ShouldBe(2);
        }
    }
}
