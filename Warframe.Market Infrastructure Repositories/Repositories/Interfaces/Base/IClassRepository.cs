using System.Linq;
using Warframe.Market_DomainModels.Abstractions;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base
{
    public interface IClassRepository<T> where T : ADomainModel
    {
        void Create (T entity);
        void Update (T entity);
        void Delete (int entityID);
        T Get (int entityID);
        IQueryable<T> GetAll();
    }
}
