using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe.Market_Infrastructure_Repositories.Base
{
    public abstract class AMappingService<TInfrastructureModel, TDomainModel, TMappingProfile> : IMappingService<TInfrastructureModel, TDomainModel>
        where TInfrastructureModel : new()
        where TDomainModel : new()
        where TMappingProfile : Profile
    {
        public TInfrastructureModel ConvertTo(TDomainModel input)
        {
            throw new NotImplementedException();
        }

        public TDomainModel ConvertTo(TInfrastructureModel input)
        {
            throw new NotImplementedException();
        }

        public void MapTo(TInfrastructureModel input, TDomainModel output)
        {
            throw new NotImplementedException();
        }

        public void MapTo(TDomainModel input, TInfrastructureModel output)
        {
            throw new NotImplementedException();
        }
    }
}
