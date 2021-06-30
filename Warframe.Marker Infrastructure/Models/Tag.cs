using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warframe.Market_Infrastructure.Models
{
    [Table(nameof(Tag))]
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
