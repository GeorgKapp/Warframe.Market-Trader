using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Warframe.Market_Infrastructure;
using Warframe.Market_Infrastructure_Repositories.Mapping;
using Warframe.Market_Infrastructure_Repositories.Repositories.EntityModelRepositories.Interfaces.RepositoryInterfaces;
using Warframe.Market_Infrastructure_Repositories.Repositories.Interfaces.ClassRepositories;

namespace Warframe.Market_Infrastructure_Repositories.Repositories.Implementation.ClassRepositories
{
    public class TagRepository : ITagRepository
    {
        private readonly IEntityTagRepository _efTagRepository;

        public TagRepository(IEntityTagRepository efTagRepository)
        {
            _efTagRepository = efTagRepository ?? throw new ArgumentNullException(nameof(efTagRepository));
        }

        public void Create(ref Market_DomainModels.Models.Tag entity)
        {
            var mappedEntityObject = ModelMapper.Map<Market_DomainModels.Models.Tag, Tag>(entity);
            _efTagRepository.Create(ref mappedEntityObject);
            ModelMapper.Map(mappedEntityObject, entity);
        }

        public void Delete(int entityID)
        {
            _efTagRepository.Delete(entityID);
        }

        public bool Exists(int entityID)
        {
            return _efTagRepository.Exists(entityID);
        }

        public Market_DomainModels.Models.Tag Get(int entityID)
        {
            return ModelMapper.Map<Market_DomainModels.Models.Tag>(_efTagRepository.Get(entityID));
        }

        public IEnumerable<Market_DomainModels.Models.Tag> Get(Expression<Func<Market_DomainModels.Models.Tag, bool>> predicate)
        {
            var mappedPredicate = ModelMapper.Map<Expression<Func<Tag, bool>>>(predicate);

            return _efTagRepository.Get(mappedPredicate)
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Tag>(predicate));
        }

        public IEnumerable<Market_DomainModels.Models.Tag> GetAll()
        {
            return _efTagRepository.GetAll()
                .ToList()
                .Select(predicate => ModelMapper.Map<Market_DomainModels.Models.Tag>(predicate));
        }

        public void Update(ref Market_DomainModels.Models.Tag entity)
        {
            var mappedModel = ModelMapper.Map<Tag>(entity);
            _efTagRepository.Update(ref mappedModel);
            ModelMapper.Map(mappedModel, entity);
        }
    }
}