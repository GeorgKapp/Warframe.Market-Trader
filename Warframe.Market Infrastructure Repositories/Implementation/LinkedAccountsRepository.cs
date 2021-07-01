using System.Linq;
using Warframe.Market_DomainModels.Enums;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Base;
using Warframe.Market_Infrastructure_Repositories.Exceptions;
using Warframe.Market_Infrastructure_Repositories.Interfaces;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Implementation
{
    public class LinkedAccountsRepository : ILinkedAccountsRepository
    {
        public void Create(Market_DomainModels.Models.LinkedAccounts entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int entityID)
        {
            throw new System.NotImplementedException();
        }

        public Market_DomainModels.Models.LinkedAccounts Get(int entityID)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Market_DomainModels.Models.LinkedAccounts> GetAll()
        {
            using (var context = new ReadOnlyEntityContext())
            {
                //var result = context.Set<Market_Infrastructure.LinkedAccounts>().Select(p => p.ApplyTo());
                return null;
            }
        }

        public void Update(Market_DomainModels.Models.LinkedAccounts entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
