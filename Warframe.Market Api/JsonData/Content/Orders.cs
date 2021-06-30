using Newtonsoft.Json;
using System;
using Warframe.Market_Api.JsonData.Enums;

namespace Warframe.Market_Api.JsonData.Content
{
    public class Orders
    {
        [JsonProperty("payload")]
        public Payload Info { get; set; }

        public class Payload
        {
            [JsonProperty("orders")]
            public Order[] Orders { get; set; }
        }

        public class Order
        {
            [JsonProperty("creation_date")]
            public DateTimeOffset CreationDate { get; set; }

            [JsonProperty("quantity")]
            public long Quantity { get; set; }

            [JsonProperty("region")]
            public Region Region { get; set; }

            [JsonProperty("visible")]
            public bool Visible { get; set; }

            [JsonProperty("platform")]
            public Platform Platform { get; set; }

            [JsonProperty("user")]
            public User User { get; set; }

            [JsonProperty("order_type")]
            public OrderType OrderType { get; set; }

            [JsonProperty("last_update")]
            public DateTimeOffset LastUpdate { get; set; }

            [JsonProperty("platinum")]
            public long Platinum { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("mod_rank", NullValueHandling = NullValueHandling.Ignore)]
            public long? ModRank { get; set; }
        }

        public class User
        {
            [JsonProperty("ingame_name")]
            public string IngameName { get; set; }

            [JsonProperty("last_seen")]
            public DateTimeOffset? LastSeen { get; set; }

            [JsonProperty("reputation")]
            public long Reputation { get; set; }

            [JsonProperty("region")]
            public Region Region { get; set; }

            [JsonProperty("status")]
            public Status Status { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("avatar")]
            public string Avatar { get; set; }
        }
    }
}