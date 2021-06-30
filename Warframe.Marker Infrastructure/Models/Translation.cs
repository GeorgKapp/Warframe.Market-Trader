using System.Collections.Generic;
using Warframe.Market_Infrastructure.Models.Enums;

namespace Warframe.Market_Infrastructure.Models
{
    public class Translation
    {
        public Translation()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public LanguageEnum LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
