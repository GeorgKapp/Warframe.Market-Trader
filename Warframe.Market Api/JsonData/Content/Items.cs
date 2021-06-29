using Newtonsoft.Json;


namespace Warframe.Market_Api.JsonData.Content
{
    public class Items
    {
        [JsonProperty("payload")]
        public Payload Info { get; set; }

        public class Payload
        {
            [JsonProperty("items")]
            public Item[] Items { get; set; }
        }

        public class Item
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("url_name")]
            public string UrlName { get; set; }

            [JsonProperty("thumb")]
            public string Thumb { get; set; }

            [JsonProperty("item_name")]
            public string ItemName { get; set; }

        }
    }
}
