using System;
using System.Data.Entity;

namespace Warframe.Market_DbContextScope
{
    public static class AmbientDbContextLocatorExtensions
    {
        /// <summary>
        /// Returns a dbcontext based on type, if no dbcontext in the ambientdbcontextlocator was found, an exception will be thrown
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="ambientDbContextLocator"></param>
        /// <returns></returns>
        public static TDbContext GetAmbientDbContextOrThrow<TDbContext>(this IAmbientDbContextLocator ambientDbContextLocator) where TDbContext : DbContext
        {
            return ambientDbContextLocator.Get<TDbContext>()
                ?? throw new InvalidOperationException($"No ambient DbContext of type {typeof(TDbContext).FullName} found. This means that this repository method has been called outside of the scope of a DbContextScope. A repository must only be accessed within the scope of a DbContextScope, which takes care of creating the DbContext instances that the repositories need and making them available as ambient contexts. This is what ensures that, for any given DbContext-derived type, the same instance is used throughout the duration of a business transaction. To fix this issue, use IDbContextScopeFactory in your top-level business logic service method to create a DbContextScope that wraps the entire business transaction that your service method implements. Then access this repository within that scope. Refer to the comments in the IDbContextScope.cs file for more details.");
        }
    }
}
