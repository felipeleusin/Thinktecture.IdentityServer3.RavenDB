namespace Thinktecture.IdentityServer3.RavenDB.Tests.Helpers
{
    using System.Collections.Generic;
    using Raven.Client;

    public static class RavenLoader
    {
        public static void LoadTo<T>(this IEnumerable<T> list, IDocumentStore store)
        {
            using (var session = store.OpenSession())
            {
                foreach (var item in list)
                {
                    session.Store(item);
                }
                session.SaveChanges();
            }    
        }
    }
}