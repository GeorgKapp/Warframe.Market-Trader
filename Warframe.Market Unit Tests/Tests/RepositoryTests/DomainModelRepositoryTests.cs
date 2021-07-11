using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Linq;
using Warframe.Market_DbContextScope;
using Warframe.Market_DomainModels.Enums;
using Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Implementation;
using Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.ClassRepositories;

namespace Warframe.Market_Unit_Tests
{
    [TestClass]
    public class DomainModelRepositoryTests
    {
        IDbContextScopeFactory _dbContextScopeFactory = new DbContextScopeFactory();
        IAmbientDbContextLocator _ambientDbContextLocator = new AmbientDbContextLocator();

        [TestMethod("1. LinkedAccounts")]
        public void Test1LinkedAccountsTests()
        {
            var repos = new LinkedAccountsDomainRepository(new LinkedAccountsEntityRepository(_ambientDbContextLocator));
            using (var dbContextScope = _dbContextScopeFactory.CreateWithTransaction(IsolationLevel.ReadCommitted))
            {
                var newAccount = new Market_DomainModels.Models.LinkedAccounts
                {
                    HasSteamProfile = true,
                    HasDiscordProfile = false,
                    HasPatreonProfile = true,
                    HasXboxProfile = true
                };

                repos.Create(ref newAccount);
                var getResult = repos.Get(newAccount.ID);
                var hasFoundOnlyOneByPredicate = repos.Get(predicate => predicate.ID == newAccount.ID).SingleOrDefault()?.ID == newAccount.ID;
                Assert.IsTrue(hasFoundOnlyOneByPredicate);
                getResult.HasSteamProfile = false;
                repos.Update(ref getResult);
                Assert.IsFalse(getResult.HasSteamProfile);
                Assert.IsTrue(getResult.HasXboxProfile);

                repos.Delete(newAccount.ID);
                Assert.ThrowsException<EntityNotFoundException>(() => repos.Get(newAccount.ID));
            }
        }

        [TestMethod("2. User")]
        public void Test2UserTests()
        {
            var repos = new UserDomainRepository(new UserEntityRepository(_ambientDbContextLocator));
            using (var dbContextScope = _dbContextScopeFactory.CreateWithTransaction(IsolationLevel.ReadCommitted))
            {
                var getResult = repos.Get(1);
                var createObject = new Market_DomainModels.Models.User
                {
                    Status = null,
                    Region = Region.En,
                    LastSeen = DateTimeOffset.Now,
                    InGameName = "Ivoken3",
                    Reputation = 37,
                    Avatar = "1231231231"
                };

                repos.Create(ref createObject);
                var reposResponse2 = repos.Get(createObject.ID);
                Assert.IsTrue(reposResponse2.ID == createObject.ID);
                repos.Delete(reposResponse2.ID);
            }
        }

        [TestMethod("3. Order")]
        public void Test3OrderTests()
        {
            var userentityrepos = new UserEntityRepository(_ambientDbContextLocator);
            var repos = new OrderDomainRepository(new OrderEntityRepository(_ambientDbContextLocator), userentityrepos);
            using (var dbContextScope = _dbContextScopeFactory.CreateWithTransaction(IsolationLevel.ReadCommitted))
            {
                var createdEntity = new Warframe.Market_DomainModels.Models.Order
                {
                    Quantity = 1,
                    Region = Region.De,
                    SubType = SubType.Flawless,
                    CreationDate = System.DateTimeOffset.Now,
                    OrderType = Market_DomainModels.Enums.OrderType.Buy,
                    Platform = Platform.Pc,
                    ModRank = null,
                    Platinum = 1000,
                    LastUpdate = System.DateTimeOffset.Now
                };

                repos.Create(ref createdEntity, 4);
                var userCount = userentityrepos.GetAll().Count();
                createdEntity.Region = Region.Pl;
                repos.Update(ref createdEntity);
                var userCount2 = userentityrepos.GetAll().Count();
                Assert.IsTrue(userCount == userCount2);
            }
        }

        [TestMethod("4. Item")]
        public void Test4ItemTests()
        {
            var userentityrepos = new UserEntityRepository(_ambientDbContextLocator);
            var repos = new OrderDomainRepository(new OrderEntityRepository(_ambientDbContextLocator), userentityrepos);
            using (var dbContextScope = _dbContextScopeFactory.CreateWithTransaction(IsolationLevel.ReadCommitted))
            {
                var createdEntity = new Warframe.Market_DomainModels.Models.Order
                {
                    Quantity = 1,
                    Region = Region.De,
                    SubType = SubType.Flawless,
                    CreationDate = System.DateTimeOffset.Now,
                    OrderType = Market_DomainModels.Enums.OrderType.Buy,
                    Platform = Platform.Pc,
                    ModRank = null,
                    Platinum = 1000,
                    LastUpdate = System.DateTimeOffset.Now
                };

                repos.Create(ref createdEntity, 4);
                var userCount = userentityrepos.GetAll().Count();
                createdEntity.Region = Region.Pl;
                repos.Update(ref createdEntity);
                var userCount2 = userentityrepos.GetAll().Count();
                Assert.IsTrue(userCount == userCount2);
            }
        }
    }
}
