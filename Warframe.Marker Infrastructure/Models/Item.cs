using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Warframe.Market_Infrastructure.Models.Enums;

namespace Warframe.Market_Infrastructure.Models
{
    [Table(nameof(Item))]
    public class Item
    {
        public Item()
        {
            Tags = new HashSet<Tag>();
            SetItems = new HashSet<SetItem>();
        }

        public int Id { get; set; }
        public string UrlName { get; set; }
        public string Thumb { get; set; }
        public int ItemNameId { get; set; }
        public virtual Translation ItemName { get; set; }
        public int WikiLInkId { get; set; }
        public Translation WikiLInk { get; set; }
        public int Ducats { get; set; }
        public int TradingTax { get; set; }
        public int MasteryLevel { get; set; }
        public int DescriptionId { get; set; }
        public Translation Description { get; set; }
        public IconFormatEnum IconFormatId { get; set; }
        public IconFormat IconFormat { get; set; }
        public string Icon { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public int? MaxRank { get; set; }

        public int ParentItemId { get; set; }
        public virtual Item ParentItem { get; set; }
        public ICollection<SetItem> SetItems { get; set; }
    }
}
