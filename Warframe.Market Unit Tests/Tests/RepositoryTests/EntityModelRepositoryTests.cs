﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warframe.Market_DbContextScope;
using Warframe.Market_DomainModels.Enums;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.EntityFrameworkRepositories;

namespace Warframe.Market_Unit_Tests.Tests
{
    [TestCategory("Entity Model Repository Tests")]
    [TestClass]
    public class EntityModelRepositoryTests
    {
        IDbContextScopeFactory _dbContextScopeFactory = new DbContextScopeFactory();
        IAmbientDbContextLocator _ambientDbContextLocator = new AmbientDbContextLocator();

        [TestMethod("EfUserRepository Test")]

        public void Test1EfUserRepository()
        {
            var repos = new EntityUserRepository(_ambientDbContextLocator);
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
    }
}
