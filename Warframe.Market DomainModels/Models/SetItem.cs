using Warframe.Market_DomainModels.Abstractions;

namespace Warframe.Market_DomainModels.Models
{
    public class SetItem : AEntity
    {
        public SetItem() { }
        public SetItem(int id) : base(id) { }

        public byte ChildQuantity { get; set; }
        public Item Child { get; set; }
        public Item Parent { get; set; }
    }
}
