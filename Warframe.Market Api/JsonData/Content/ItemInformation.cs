using Newtonsoft.Json;
using System;
using Warframe.Market_Api.JsonData.Enums;

namespace Warframe.Market_Api.JsonData.Content
{
    public class ItemInformation
    {
        [JsonProperty("payload")]
        public Payload Info { get; set; }

        public class Payload
        {
            [JsonProperty("item")]
            public Item Item { get; set; }
        }

        public class Item
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("items_in_set")]
            public ItemsInSet[] ItemsInSet { get; set; }
        }

        public class ItemsInSet
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("url_name")]
            public string UrlName { get; set; }

            [JsonProperty("icon_format")]
            public IconFormat IconFormat { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }

            [JsonProperty("sub_icon")]
            public string SubIcon { get; set; }

            [JsonProperty("trading_tax")]
            public long TradingTax { get; set; }

            [JsonProperty("set_root")]
            public bool SetRoot { get; set; }

            [JsonProperty("thumb")]
            public string Thumb { get; set; }

            [JsonProperty("ducats")]
            public long Ducats { get; set; }

            [JsonProperty("tags")]
            public string[] Tags { get; set; }

            [JsonProperty("mastery_level")]
            public long MasteryLevel { get; set; }

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

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("wiki_link")]
            public Uri WikiLink { get; set; }

            [JsonProperty("drop")]
            public Drop[] Drop { get; set; }
        }

        public class Drop
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("link")]
            public string Link { get; set; }
        }
    }
}
