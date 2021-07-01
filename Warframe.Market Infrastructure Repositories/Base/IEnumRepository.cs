using System;
using System.Linq;

namespace Warframe.Market_Infrastructure_Repositories.Base
{
    public interface IEnumRepository<T> where T : Enum
    {
        T Get(int entityID);
        IQueryable<T> GetAll();
    }
}
