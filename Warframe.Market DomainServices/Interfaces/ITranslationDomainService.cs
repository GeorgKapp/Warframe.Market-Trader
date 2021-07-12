using Warframe.Market_DomainModels.Enums;

namespace Warframe.Market_DomainServices.Interfaces
{
    public interface ITranslationDomainService
    {
        Market_DomainModels.Models.Translation CreateOrGetTranslationByRegionValue(string value, Region region);
        Market_DomainModels.Models.Translation CreateOrGetTranslationByEnglishValue(string value);
    }
}
