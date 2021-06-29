using Newtonsoft.Json;
using Warframe.Market_Api.JsonData.Enums;

namespace Warframe.Market_Api.JsonData.Content
{
    public class LogoutResponse
    {
        [JsonProperty("payload")]
        public Payload Info { get; set; }

        public partial class Payload
        {
            [JsonProperty("user")]
            public User User { get; set; }
        }

        public partial class User
        {
            [JsonProperty("region")]
            public Region Region { get; set; }

            [JsonProperty("written_reviews")]
            public long WrittenReviews { get; set; }

            [JsonProperty("check_code")]
            public object CheckCode { get; set; }

            [JsonProperty("reputation")]
            public long Reputation { get; set; }

            [JsonProperty("verification")]
            public bool Verification { get; set; }

            [JsonProperty("unread_messages")]
            public long UnreadMessages { get; set; }

            [JsonProperty("role")]
            public Role Role { get; set; }

            [JsonProperty("platform")]
            public Platform Platform { get; set; }

            [JsonProperty("banned")]
            public bool Banned { get; set; }

            [JsonProperty("anonymous")]
            public bool Anonymous { get; set; }

            [JsonProperty("has_mail")]
            public bool HasMail { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("linked_accounts")]
            public LinkedAccounts LinkedAccounts { get; set; }
        }

        public partial class LinkedAccounts
        {
            [JsonProperty("steam_profile")]
            public bool SteamProfile { get; set; }

            [JsonProperty("patreon_profile")]
            public bool PatreonProfile { get; set; }

            [JsonProperty("xbox_profile")]
            public bool XboxProfile { get; set; }
        }
    }
}
