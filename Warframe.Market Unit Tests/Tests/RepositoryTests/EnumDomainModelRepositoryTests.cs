using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Warframe.Market_DbContextScope;
using Warframe.Market_DomainModels.Enums;
using Warframe.Market_Infrastructure_Repositories.Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.EnumRepositories;

namespace Warframe.Market_Unit_Tests
{
    [TestCategory("Enum Domain Model Repository Tests")]
    [TestClass]
    public class EnumDomainModelRepositoryTests
    {
        IDbContextScopeFactory _dbContextScopeFactory = new DbContextScopeFactory();
        IAmbientDbContextLocator _ambientDbContextLocator = new AmbientDbContextLocator();


        [TestMethod("IconFormat Get()")]

        public void Test1IconFormatGetByID()
        {
            var repos = new IconFormatRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var enumValues = GetAllEnumValues<IconFormat>();
                for(int i = 1; i <= enumValues.Length; i++)
                {
                    var enumEntity = repos.Get(i);
                    Assert.IsTrue(CheckIfEnumIdAndValueMatch(i, enumEntity));
                }
                Assert.ThrowsException<EntityNotFoundException>(() => repos.Get(enumValues.Length + 1));
            }
        }


        [TestMethod("IconFormat GetAll()")]

        public void Test2IconFormatGetAll()
        {
            var repos = new IconFormatRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var results = repos.GetAll();
                Assert.IsTrue(CheckIfEnumValuesArePresent(results));
            }
        }

        [TestMethod("OrderType Get()")]

        public void Test3OrderTypeGetByID()
        {
            var repos = new OrderTypeRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var enumValues = GetAllEnumValues<OrderType>();
                for (int i = 1; i <= enumValues.Length; i++)
                {
                    var enumEntity = repos.Get(i);
                    Assert.IsTrue(CheckIfEnumIdAndValueMatch(i, enumEntity));
                }
                Assert.ThrowsException<EntityNotFoundException>(() => repos.Get(enumValues.Length + 1));
            }
        }

        [TestMethod("OrderType GetAll()")]

        public void Test4OrderTypeGetAll()
        {
            var repos = new OrderTypeRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var results = repos.GetAll();
                Assert.IsTrue(CheckIfEnumValuesArePresent(results));
            }
        }

        [TestMethod("Platform Get()")]

        public void Test5PlatformGetByID()
        {
            var repos = new PlatformRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var enumValues = GetAllEnumValues<Platform>();
                for (int i = 1; i <= enumValues.Length; i++)
                {
                    var enumEntity = repos.Get(i);
                    Assert.IsTrue(CheckIfEnumIdAndValueMatch(i, enumEntity));
                }
                Assert.ThrowsException<EntityNotFoundException>(() => repos.Get(enumValues.Length + 1));
            }
        }

        [TestMethod("Platform GetAll()")]

        public void Test6PlatformGetAll()
        {
            var repos = new PlatformRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var results = repos.GetAll();
                Assert.IsTrue(CheckIfEnumValuesArePresent(results));
            }
        }

        [TestMethod("Region Get()")]

        public void Test7RegionGetByID()
        {
            var repos = new RegionRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var enumValues = GetAllEnumValues<Region>();
                for (int i = 1; i <= enumValues.Length; i++)
                {
                    var enumEntity = repos.Get(i);
                    Assert.IsTrue(CheckIfEnumIdAndValueMatch(i, enumEntity));
                }
                Assert.ThrowsException<EntityNotFoundException>(() => repos.Get(enumValues.Length + 1));
            }
        }

        [TestMethod("Region GetAll()")]

        public void Test8RegionGetAll()
        {
            var repos = new RegionRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var results = repos.GetAll();
                Assert.IsTrue(CheckIfEnumValuesArePresent(results));
            }
        }

        [TestMethod("Role Get()")]

        public void Test9RoleGetByID()
        {
            var repos = new RoleRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var enumValues = GetAllEnumValues<Role>();
                for (int i = 1; i <= enumValues.Length; i++)
                {
                    var enumEntity = repos.Get(i);
                    Assert.IsTrue(CheckIfEnumIdAndValueMatch(i, enumEntity));
                }
                Assert.ThrowsException<EntityNotFoundException>(() => repos.Get(enumValues.Length + 1));
            }
        }

        [TestMethod("Role GetAll()")]

        public void Test10RoleGetAll()
        {
            var repos = new RoleRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var results = repos.GetAll();
                Assert.IsTrue(CheckIfEnumValuesArePresent(results));
            }
        }

        [TestMethod("Status Get()")]

        public void Test11StatusGetByID()
        {
            var repos = new StatusRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var enumValues = GetAllEnumValues<Status>();
                for (int i = 1; i <= enumValues.Length; i++)
                {
                    var enumEntity = repos.Get(i);
                    Assert.IsTrue(CheckIfEnumIdAndValueMatch(i, enumEntity));
                }
                Assert.ThrowsException<EntityNotFoundException>(() => repos.Get(enumValues.Length + 1));
            }
        }

        [TestMethod("Status GetAll()")]

        public void Test12StatusGetAll()
        {
            var repos = new StatusRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var results = repos.GetAll();
                Assert.IsTrue(CheckIfEnumValuesArePresent(results));
            }
        }

        [TestMethod("SubType Get()")]

        public void Test13SubTypeGetByID()
        {
            var repos = new SubTypeRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var enumValues = GetAllEnumValues<SubType>();
                for (int i = 1; i <= enumValues.Length; i++)
                {
                    var enumEntity = repos.Get(i);
                    Assert.IsTrue(CheckIfEnumIdAndValueMatch(i, enumEntity));
                }
                Assert.ThrowsException<EntityNotFoundException>(() => repos.Get(enumValues.Length + 1));
            }
        }

        [TestMethod("SubType GetAll()")]

        public void Test14SubTypeGetAll()
        {
            var repos = new SubTypeRepository(_ambientDbContextLocator);
            using (var dbContextScope = _dbContextScopeFactory.CreateReadOnly())
            {
                var results = repos.GetAll();
                Assert.IsTrue(CheckIfEnumValuesArePresent(results));
            }
        }


        private bool CheckIfEnumIdAndValueMatch<TEnum>(int id, TEnum enumValue) where TEnum : Enum
        {
            return EqualityComparer<TEnum>.Default.Equals((TEnum)(object)id, enumValue);
        }

        private bool CheckIfEnumValuesArePresent<TEnum>(IEnumerable<TEnum> resultList) where TEnum : Enum
        {
            var checkList = GetAllEnumValues<TEnum>();
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

        private TEnum[] GetAllEnumValues<TEnum>() where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
        }
    }
}
