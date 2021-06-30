using System.ComponentModel.DataAnnotations.Schema;

namespace Warframe.Market_Infrastructure.Models.Enums
{
    [Table(nameof(OrderType))]
    public class OrderType
    {
        public OrderTypeEnum Id { get; set; }
        public string Name { get; set; }
    }
}
