using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Interfaces.Base
{
    public interface IEntityRepository<TEntity> 
        where TEntity : class
    {
        void Create(ref TEntity entity);
        void Update(ref TEntity entity);
        void Delete(int entityID);
        bool Exists(int entityID);
        TEntity Get(int entityID);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
    }
}
