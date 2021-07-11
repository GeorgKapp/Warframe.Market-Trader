using Warframe.Market_DomainModels.Abstractions;

namespace Warframe.Market_DomainModels.Models
{
    public class ItemTag : ADomainModel
    {
        public ItemTag() { }
        public ItemTag(int id) : base(id) { }

        public Item Item { get; private set; }
        public Tag Tag { get; private set; }
    }
}
