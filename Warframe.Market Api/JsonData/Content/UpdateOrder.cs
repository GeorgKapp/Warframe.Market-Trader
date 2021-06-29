using Newtonsoft.Json;

namespace Warframe.Market_Api.JsonData.Content
{
    public class UpdateOrder
    {
        [JsonProperty("order_id")]
        public string OrderID { get; set; }

        [JsonProperty("platinum")]
        public long Platinum { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty(("rank"), NullValueHandling = NullValueHandling.Ignore)]
        public long? Rank { get; set; }
    }
}
