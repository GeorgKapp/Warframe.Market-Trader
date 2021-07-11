using System.Collections.Generic;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Interfaces.Base
{
    public interface IEntityReadonlyRepository<TEntity>
         where TEntity : class
    {
        bool Exists(int entityID);
        TEntity Get(int entityID);
        IEnumerable<TEntity> GetAll();
    }
}
