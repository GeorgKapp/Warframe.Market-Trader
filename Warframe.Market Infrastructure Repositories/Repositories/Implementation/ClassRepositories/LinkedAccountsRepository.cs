using System;
using System.Linq;
using Warframe.Market_DomainModels.Models;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.ClassRepositories
{
    public class LinkedAccountsRepository : ILinkedAccountsRepository
    {
        //IDbContextFactory _dbContextFactory;
        //public LinkedAccountsRepository(IDbContextFactory dbContextFactory)
        //{
        //    _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        //}

        //public void Create(Market_DomainModels.Models.LinkedAccounts entity)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void Delete(int entityID)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public Market_DomainModels.Models.LinkedAccounts Get(int entityID)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public IQueryable<Market_DomainModels.Models.LinkedAccounts> GetAll()
        //{
        //    using (var context = _dbContextFactory.CreateReadOnly())
        //    {
        //        //var result = context.Set<Market_Infrastructure.LinkedAccounts>().Select(p => p.ApplyTo());
        //        return null;
        //    }
        //}

        //public void Update(Market_DomainModels.Models.LinkedAccounts entity)
        //{
        //    throw new System.NotImplementedException();
        //}

        public void Create(LinkedAccounts entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityID)
        {
            throw new NotImplementedException();
        }

        public LinkedAccounts Get(int entityID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<LinkedAccounts> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(LinkedAccounts entity)
        {
            throw new NotImplementedException();
        }
    }
}
