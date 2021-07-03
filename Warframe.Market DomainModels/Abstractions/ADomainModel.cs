namespace Warframe.Market_DomainModels.Abstractions
{
    public abstract class ADomainModel
    {
        public ADomainModel() { }
        public ADomainModel(int id)
        {
            ID = id;
        }

        public int ID { get; private set; }
    }
}
