using Newtonsoft.Json;
using Warframe.Market_Api.JsonData.Enums;

namespace Warframe.Market_Api.JsonData.Content
{
    public class CreateOrderRequest
    {
        [JsonProperty("order_type")]
        public OrderType OrderType { get; set; }

        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        [JsonProperty("platinum")]
        public long Platinum { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty("subtype", NullValueHandling = NullValueHandling.Ignore)]
        public SubType? Subtype { get; set; }
    }
}
