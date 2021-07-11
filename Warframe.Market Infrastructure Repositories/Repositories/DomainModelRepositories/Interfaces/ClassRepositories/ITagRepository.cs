using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.Base;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories
{
    public interface ITagRepository : IClassDomainModelRepository<Tag, Market_DomainModels.Models.Tag> { }
}
