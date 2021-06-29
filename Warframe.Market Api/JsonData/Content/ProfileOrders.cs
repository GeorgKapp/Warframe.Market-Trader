using Newtonsoft.Json;
using System;

namespace Warframe.Market_Api.JsonData.Content
{
    public class ProfileOrders
    {
        [JsonProperty("payload")]
        public Payload Info { get; set; }

        public class Payload
        {
            [JsonProperty("sell_orders")]
            public Order[] SellOrders { get; set; }

            [JsonProperty("buy_orders")]
            public Order[] BuyOrders { get; set; }
        }

        public class Order
        {
            [JsonProperty("platform")]
            public Platform Platform { get; set; }

            [JsonProperty("platinum")]
            public long Platinum { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("order_type")]
            public OrderType OrderType { get; set; }

            [JsonProperty("region")]
            public Region Region { get; set; }

            [JsonProperty("visible")]
            public bool Visible { get; set; }

            [JsonProperty("item")]
            public Item Item { get; set; }

            [JsonProperty("creation_date")]
            public DateTimeOffset CreationDate { get; set; }

            [JsonProperty("quantity")]
            public long Quantity { get; set; }

            [JsonProperty("last_update")]
            public DateTimeOffset LastUpdate { get; set; }

            [JsonProperty("mod_rank", NullValueHandling = NullValueHandling.Ignore)]
            public long? ModRank { get; set; }
        }

        public class Item
        {
            [JsonProperty("sub_icon")]
            public string SubIcon { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("thumb")]
            public string Thumb { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }

            [JsonProperty("icon_format")]
            public IconFormat IconFormat { get; set; }

            [JsonProperty("url_name")]
            public string UrlName { get; set; }

            [JsonProperty("tags")]
            public string[] Tags { get; set; }

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

            [JsonProperty("mod_max_rank", NullValueHandling = NullValueHandling.Ignore)]
            public long? ModMaxRank { get; set; }

            [JsonProperty("ducats", NullValueHandling = NullValueHandling.Ignore)]
            public long? Ducats { get; set; }
        }

        public class Language
        {
            [JsonProperty("item_name")]
            public string ItemName { get; set; }
        }

        public enum IconFormat { Land, Port };

        public enum OrderType { Buy, Sell };

        public enum Platform { Pc };

        public enum Region { En };
    }
}
