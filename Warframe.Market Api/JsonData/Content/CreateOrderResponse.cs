using Newtonsoft.Json;
using System;
using Warframe.Market_Api.JsonData.Enums;

namespace Warframe.Market_Api.JsonData.Content
{
    public class CreateOrderResponse
    {
        [JsonProperty("payload")]
        public Payload Info { get; set; }

        public class Payload
        {
            [JsonProperty("order")]
            public Order Order { get; set; }
        }

        public class Order
        {
            [JsonProperty("order_type")]
            public OrderType OrderType { get; set; }

            [JsonProperty("platinum")]
            public long Platinum { get; set; }

            [JsonProperty("visible")]
            public bool Visible { get; set; }

            [JsonProperty("item")]
            public Item Item { get; set; }

            [JsonProperty("creation_date")]
            public DateTimeOffset CreationDate { get; set; }

            [JsonProperty("last_update")]
            public DateTimeOffset LastUpdate { get; set; }

            [JsonProperty("subtype")]
            public SubType Subtype { get; set; }

            [JsonProperty("platform")]
            public Platform Platform { get; set; }

            [JsonProperty("quantity")]
            public long Quantity { get; set; }

            [JsonProperty("region")]
            public Region Region { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }
        }

        public class Item
        {
            [JsonProperty("tags")]
            public string[] Tags { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }

            [JsonProperty("url_name")]
            public string UrlName { get; set; }

            [JsonProperty("sub_icon")]
            public object SubIcon { get; set; }

            [JsonProperty("thumb")]
            public string Thumb { get; set; }

            [JsonProperty("icon_format")]
            public IconFormat IconFormat { get; set; }

            [JsonProperty("subtypes")]
            public SubType[] Subtypes { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("en")]
            public Language En { get; set; }

            [JsonProperty("ru")]
            public Language Ru { get; set; }

            [JsonProperty("ko")]
            public Language Ko { get; set; }

            [JsonProperty("fr")]
            public Language Fr { get; set; }

            [JsonProperty("sv")]
            public Language Sv { get; set; }

            [JsonProperty("de")]
            public Language De { get; set; }

            [JsonProperty("zh-hant")]
            public Language ZhHant { get; set; }

            [JsonProperty("zh-hans")]
            public Language ZhHans { get; set; }

            [JsonProperty("pt")]
            public Language Pt { get; set; }

            [JsonProperty("es")]
            public Language Es { get; set; }

            [JsonProperty("pl")]
            public Language Pl { get; set; }
        }

        public class Language
        {
            [JsonProperty("item_name")]
            public string ItemName { get; set; }
        }
    }
}
