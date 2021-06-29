using Newtonsoft.Json;

namespace Warframe.Market_Api.JsonData.Content
{
    public class DeleteOrderResponse
    {
        [JsonProperty("payload")]
        public Payload Info { get; set; }

        public partial class Payload
        {
            [JsonProperty("order_id")]
            public string OrderID { get; set; }
        }
    }
}
