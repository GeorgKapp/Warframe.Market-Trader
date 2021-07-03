using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Warframe.Market_Infrastructure.DbContextScope;
using Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.EnumRepositories;

namespace Warframe.Market_Unit_Tests
{
    [TestClass]
    public class RepositoryUnitTests
    {
        IDbContextScopeFactory _dbContextScopeFactory = new DbContextScopeFactory();
        IAmbientDbContextLocator _ambientDbContextLocator = new AmbientDbContextLocator();

        [TestMethod("Icon Format Repository Test")]

        public void Test1IconFormatRepository()
        {
            var repos = new IconFormatRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var results = repos.GetAll();
                Assert.IsTrue(CheckIfEnumValuesArePresent(results));
            }
        }

        [TestMethod("Order Type Repository Test")]

        public void Test2OrderTypeRepository()
        {
            var repos = new OrderTypeRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var results = repos.GetAll();
                Assert.IsTrue(CheckIfEnumValuesArePresent(results));
            }
        }

        [TestMethod("Platform Repository Test")]

        public void Test3PlatformRepository()
        {
            var repos = new PlatformRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var results = repos.GetAll();
                Assert.IsTrue(CheckIfEnumValuesArePresent(results));
            }
        }

        [TestMethod("Region Repository Test")]

        public void Test4RegionRepository()
        {
            var repos = new RegionRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var results = repos.GetAll();
                Assert.IsTrue(CheckIfEnumValuesArePresent(results));
            }
        }

        [TestMethod("Role Repository Test")]

        public void Test5RoleRepository()
        {
            var repos = new RoleRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var results = repos.GetAll();
                Assert.IsTrue(CheckIfEnumValuesArePresent(results));
            }
        }

        [TestMethod("Status Repository Test")]

        public void Test5StatusRepository()
        {
            var repos = new StatusRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var results = repos.GetAll();
                Assert.IsTrue(CheckIfEnumValuesArePresent(results));
            }
        }

        [TestMethod("SubType Repository Test")]

        public void Test5SubTypeRepository()
        {
            var repos = new SubTypeRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var results = repos.GetAll();
                Assert.IsTrue(CheckIfEnumValuesArePresent(results));
            }
        }

        private bool CheckIfEnumValuesArePresent<TEnum>(IEnumerable<TEnum> resultList) where TEnum : Enum
        {
            var checkList = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            if(checkList.Count() == resultList.Count())
            {
                foreach(var checkListItem in checkList)
                {
                    if (!resultList.Contains(checkListItem))
                        return false;
                }
                return true;
            }
            return false;
        }
    }
}
