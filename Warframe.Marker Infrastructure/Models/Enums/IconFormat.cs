using System.ComponentModel.DataAnnotations.Schema;

namespace Warframe.Market_Infrastructure.Models.Enums
{
    [Table(nameof(IconFormat))]
    public class IconFormat
    {
        public IconFormatEnum Id { get; set; }
        public string Name { get; set; }
    }
}
