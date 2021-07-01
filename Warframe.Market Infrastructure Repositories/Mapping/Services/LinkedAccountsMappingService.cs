using AutoMapper;
using Warframe.Market_Infrastructure_Repositories.Base;
using Warframe.Market_Infrastructure_Repositories.Mapping.Profiles;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Services
{
    public class LinkedAccountsMappingService : IMappingService<Market_Infrastructure.LinkedAccounts, Market_DomainModels.Models.LinkedAccounts>
    {
        private static IMapper Mapper = new MapperConfiguration(p =>
        {
            p.AddProfile<LinkedAccountsMappingProfile>();
        }).CreateMapper();

        public Market_Infrastructure.LinkedAccounts ConvertTo(Market_DomainModels.Models.LinkedAccounts input)
        {
            var output = new Market_Infrastructure.LinkedAccounts();
            Mapper.Map(input, output);
            return output;
        }

        public Market_DomainModels.Models.LinkedAccounts ConvertTo(Market_Infrastructure.LinkedAccounts input)
        {
            var output = new Market_DomainModels.Models.LinkedAccounts();
            Mapper.Map(input, output);
            return output;
        }

        public void MapTo(Market_Infrastructure.LinkedAccounts input, Market_DomainModels.Models.LinkedAccounts output)
        {
            Mapper.Map(input, output);
        }

        public void MapTo(Market_DomainModels.Models.LinkedAccounts input, Market_Infrastructure.LinkedAccounts output)
        {
            Mapper.Map(input, output);
        }
    }
}
