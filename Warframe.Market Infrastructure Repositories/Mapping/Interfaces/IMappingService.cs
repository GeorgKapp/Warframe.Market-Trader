namespace Warframe.Market_Infrastructure_Repositories.Base
{
    public interface IMappingService<TInfrastructureModel, TDomainModel> 
        where TInfrastructureModel : new()
        where TDomainModel : new()
    {
        public void MapTo(TInfrastructureModel input, TDomainModel output);
        public void MapTo(TDomainModel input, TInfrastructureModel output);
        public TInfrastructureModel ConvertTo(TDomainModel input);
        public TDomainModel ConvertTo(TInfrastructureModel input);
    }
}
