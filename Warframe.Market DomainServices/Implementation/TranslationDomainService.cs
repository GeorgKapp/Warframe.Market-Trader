using System;
using System.Linq;
using Warframe.Market_DomainModels.Enums;
using Warframe.Market_DomainModels.Models;
using Warframe.Market_DomainServices.Interfaces;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories;

namespace Warframe.Market_DomainServices.Implementation
{
    public class TranslationDomainService : ITranslationDomainService
    {
        private readonly ITranslationDomainRepository _translationDomainRepository;
        public TranslationDomainService(ITranslationDomainRepository translationDomainRepository)
        {
            _translationDomainRepository = translationDomainRepository ?? throw new ArgumentNullException(nameof(translationDomainRepository));
        }

        public Translation CreateOrGetTranslationByEnglishValue(string value)
            => CreateOrGetTranslationByRegionValue(value, Region.En);

        public Translation CreateOrGetTranslationByRegionValue(string value, Region region)
        {
            var foundTranslation = region switch
            {
                Region.En => _translationDomainRepository.Get(p => p.En == value).SingleOrDefault(),
                Region.De => _translationDomainRepository.Get(p => p.De == value).SingleOrDefault(),
                Region.Fr => _translationDomainRepository.Get(p => p.Fr == value).SingleOrDefault(),
                Region.Ko => _translationDomainRepository.Get(p => p.Ko == value).SingleOrDefault(),
                Region.Ru => _translationDomainRepository.Get(p => p.Ru == value).SingleOrDefault(),
                Region.Sv => _translationDomainRepository.Get(p => p.Sv == value).SingleOrDefault(),
                Region.ZhHant => _translationDomainRepository.Get(p => p.ZhHant == value).SingleOrDefault(),
                Region.ZhHans => _translationDomainRepository.Get(p => p.ZhHans == value).SingleOrDefault(),
                Region.Pt => _translationDomainRepository.Get(p => p.Pt == value).SingleOrDefault(),
                Region.Es => _translationDomainRepository.Get(p => p.Es == value).SingleOrDefault(),
                Region.Pl => _translationDomainRepository.Get(p => p.Pl == value).SingleOrDefault(),
                _ => throw new NotImplementedException($"{region} has not been implemented yet in the translation domain service"),
            };

            if (foundTranslation is null)
            {
                var newtranslation = new Translation { En = value };
                _translationDomainRepository.Create(ref newtranslation);
                return newtranslation;
            }
            return foundTranslation;
        }
    }
}
