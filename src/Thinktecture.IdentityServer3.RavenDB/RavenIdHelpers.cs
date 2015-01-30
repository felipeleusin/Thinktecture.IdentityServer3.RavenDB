namespace Thinktecture.IdentityServer3.RavenDB
{
    using System.Threading.Tasks;
    using Raven.Client;

    public static class RavenIdHelpers
    {
        public static Task<T> LoadWithTagId<T>(this IAsyncDocumentSession session, string id)
        {
            return session.LoadAsync<T>(session.Advanced.DocumentStore.Conventions.FindTypeTagName(typeof (T)) + "/" + id);
        }
    }
}
