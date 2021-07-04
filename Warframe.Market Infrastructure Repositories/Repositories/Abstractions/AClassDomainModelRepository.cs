using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Warframe.Market_DomainModels.Abstractions;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Abstractions
{
    class AClassDomainModelRepository<TEntity, TClass, TContext> : IClassDomainModelRepository<TEntity, TClass>
        where TEntity : class
        where TClass : ADomainModel
        where TContext : DbContext
    {
        public void Create(ref TClass entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityID)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int entityID)
        {
            throw new NotImplementedException();
        }

        public TClass Get(int entityID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TClass> Get(Expression<Func<TClass, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TClass> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ref TClass entity)
        {
            throw new NotImplementedException();
        }
    }
}
