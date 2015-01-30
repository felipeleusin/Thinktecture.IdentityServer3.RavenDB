namespace Thinktecture.IdentityServer3.RavenDB.Tests.Helpers
{
    using System.Collections.Generic;
    using IdentityServer.Core.Models;

    public class TestScopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new Scope[]
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.Email,
                StandardScopes.OfflineAccess,
                new Scope
                {
                    Name = "read",
                    DisplayName = "Read data",
                    Type = ScopeType.Resource,
                    Emphasize = false,
                },
                new Scope
                {
                    Name = "write",
                    DisplayName = "Write data",
                    Type = ScopeType.Resource,
                    Emphasize = true,
                },
                new Scope
                {
                    Name = "not_public",
                    ShowInDiscoveryDocument = false,
                    DisplayName = "Restricted Scope",
                    Type = ScopeType.Resource,
                    Emphasize = false
                },
                new Scope
                {
                    Name = "very_public",
                    ShowInDiscoveryDocument = false,
                    DisplayName = "Public Scope",
                    Type = ScopeType.Resource,
                    Emphasize = false
                }
            };
        }
    }
}