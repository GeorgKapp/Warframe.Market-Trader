using System.Linq;
using Warframe.Market_DomainModels.Abstractions;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base
{
    public interface IClassDomainModelRepository<T> where T : ADomainModel
    {
        void Create (ref T entity);
        void Update (ref T entity);
        void Delete (int entityID);
        bool Exists(int entityID);
        T Get (int entityID);
        IQueryable<T> GetAll();
    }
}
