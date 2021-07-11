using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Linq;
using Warframe.Market_DbContextScope;
using Warframe.Market_DomainModels.Enums;
using Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Implementation;
using Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.ClassRepositories;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories;

namespace Warframe.Market_Unit_Tests.Tests.RepositoryTests
{
    [TestCategory("Domain Model Repository Tests")]
    [TestClass]
    public class DomainModelRepositoryTests
    {
        IDbContextScopeFactory _dbContextScopeFactory = new DbContextScopeFactory();
        IAmbientDbContextLocator _ambientDbContextLocator = new AmbientDbContextLocator();
        ILinkedAccountsRepository _linkedAccountsRepository;
        IUserRepository _userRepository;
        IOrderRepository _orderRepository;

        [ClassInitialize]
        public void ClassInitialize(TestContext context)
        {
            _linkedAccountsRepository = new LinkedAccountsRepository(new EntityLinkedAccountsRepository(_ambientDbContextLocator));
            _userRepository = new UserRepository(new EntityUserRepository(_ambientDbContextLocator));
            _orderRepository = new OrderRepository(new EntityOrderRepository(_ambientDbContextLocator));
        }

        [TestMethod("LinkedAccounts Create, Update, Delete")]
        public void Test1LinkedAccountsTests()
        {
            using (var dbContextScope = _dbContextScopeFactory.CreateWithTransaction(IsolationLevel.ReadCommitted))
            {
                var newAccount = new Market_DomainModels.Models.LinkedAccounts
                {
                    HasSteamProfile = true,
                    HasDiscordProfile = false,
                    HasPatreonProfile = true,
                    HasXboxProfile = true
                };

                _linkedAccountsRepository.Create(ref newAccount);
                var getResult = _linkedAccountsRepository.Get(newAccount.ID);
                var hasFoundOnlyOneByPredicate = _linkedAccountsRepository.Get(predicate => predicate.ID == newAccount.ID).SingleOrDefault()?.ID == newAccount.ID;
                Assert.IsTrue(hasFoundOnlyOneByPredicate);
                getResult.HasSteamProfile = false;
                _linkedAccountsRepository.Update(ref getResult);
                Assert.IsFalse(getResult.HasSteamProfile);
                Assert.IsTrue(getResult.HasXboxProfile);

                _linkedAccountsRepository.Delete(newAccount.ID);
                Assert.ThrowsException<EntityNotFoundException>(() => _linkedAccountsRepository.Get(newAccount.ID));
            }
        }

        [TestMethod("User Get 1 / Create")]
        public void Test2UserTests()
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                var getResult = _userRepository.Get(1);
                var createObject = new Market_DomainModels.Models.User
                {
                    Status = null,
                    Region = Region.En,
                    LastSeen = DateTimeOffset.Now,
                    InGameName = "Ivoken3",
                    Reputation = 37,
                    Avatar = "1231231231"
                };

                _userRepository.Create(ref createObject);
                var reposResponse2 = _userRepository.Get(createObject.ID);
                dbContextScope.SaveChanges();
                _ = "";
            }
        }

        [TestMethod("Order Create, Update, Delete")]
        public void Test3OrderTests()
        {
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                var getResult = _orderRepository.Get(1);
                _ = "";
            }
        }
    }
}
