namespace Warframe.Market_DomainModels.Models
{
    public class SetItem
    {
        public byte ChildQuantity { get; set; }
        public Item Child { get; set; }
        public Item Parent { get; set; }
    }
}
