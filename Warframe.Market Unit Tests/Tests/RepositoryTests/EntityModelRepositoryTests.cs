using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warframe.Market_DbContextScope;
using Warframe.Market_DomainModels.Enums;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Implementation;

namespace Warframe.Market_Unit_Tests
{
    [TestClass]
    public class EntityModelRepositoryTests
    {
        IDbContextScopeFactory _dbContextScopeFactory = new DbContextScopeFactory();
        IAmbientDbContextLocator _ambientDbContextLocator = new AmbientDbContextLocator();

        [TestMethod("EfUserRepository Test")]
        public void Test1EfUserRepository()
        {
            var repos = new UserEntityRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var createdEntity = new User
                {
                    ID = 1232,
                    InGameName = "test user",
                    RegionID = (int)Region.De,
                    StatusID = (int)Status.Offline,
                };

                repos.Create(ref createdEntity);
                var gottenentity = repos.Get(createdEntity.ID);
                createdEntity.RegionID = (int)Region.Fr;
                repos.Update(ref createdEntity);

                //var entity = repos.Get(4);
                //entity.LastSeen = DateTimeOffset.Now;
                //repos.Update(ref entity);
                _ = "";
            }
        }


        [TestMethod("EfOrderRepository Test")]
        public void Test2EfOrderRepository()
        {
            var repos = new OrderEntityRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var gottenentity = repos.Get(1006);

                //var entity = repos.Get(4);
                //entity.LastSeen = DateTimeOffset.Now;
                //repos.Update(ref entity);
                _ = "";
            }
        }
    }
}
