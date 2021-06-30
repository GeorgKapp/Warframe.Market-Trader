using System.Collections.Generic;

namespace Warframe.Market_Infrastructure.Models
{
    public class Tag
    {
        public Tag()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
