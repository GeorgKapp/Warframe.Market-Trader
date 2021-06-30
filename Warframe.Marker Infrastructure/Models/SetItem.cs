using System.ComponentModel.DataAnnotations.Schema;

namespace Warframe.Market_Infrastructure.Models
{
    [Table(nameof(SetItem))]
    public class SetItem
    {
        public int ParentId { get; set; }
        public virtual Item Parent { get; set; }

        public int ChildId { get; set; }
        public virtual Item Child { get; set; }

        public int ChildrenQuantity { get; set; }
    }
}
