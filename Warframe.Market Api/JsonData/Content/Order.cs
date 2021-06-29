using Newtonsoft.Json;
using Warframe.Market_Api.JsonData.Enums;

namespace Warframe.Market_Api.JsonData.Content
{
    public class Order
    {
        [JsonProperty("item")]
        public string Item { get; set; }

        [JsonProperty("order_type")]
        public OrderType OrderType { get; set; }

        [JsonProperty("platinum")]
        public long Platinum { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty("rank")]
        public long Rank { get; set; }

        [JsonProperty("subtype")]
        public SubType Subtype { get; set; }
    }
}
