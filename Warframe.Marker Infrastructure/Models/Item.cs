using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warframe.Market_Infrastructure.Models.Enums;

namespace Warframe.Market_Infrastructure.Models
{
    public class Item
    {
        public Item()
        {
            Tags = new HashSet<Tag>();
            ItemsInSet = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string UrlName { get; set; }
        public string Thumb { get; set; }
        public Translation ItemName { get; set; }
        public int Ducats { get; set; }
        public int TradingTax { get; set; }
        public int MasteryLevel { get; set; }
        public string Description { get; set; }
        public IconFormatEnum IconFormat { get; set; }
        public string Icon { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public int? ModMaxRank { get; set; }

        public Item ParentItem { get; set; }
        public ICollection<Item> ItemsInSet { get; set; }
    }
}
