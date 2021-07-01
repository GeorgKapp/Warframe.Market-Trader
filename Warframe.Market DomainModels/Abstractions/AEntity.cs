namespace Warframe.Market_DomainModels.Abstractions
{
    public abstract class AEntity
    {
        public AEntity() { }
        public AEntity(int id)
        {
            ID = id;
        }

        public int ID { get; private set; }
    }
}
