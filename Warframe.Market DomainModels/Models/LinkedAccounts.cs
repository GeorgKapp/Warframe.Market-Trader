using Warframe.Market_DomainModels.Abstractions;

namespace Warframe.Market_DomainModels.Models
{
    public class LinkedAccounts : ADomainModel
    {
        public LinkedAccounts() { }
        public LinkedAccounts(int id) : base(id) { }

        public bool HasSteamProfile { get; set; }
        public bool HasPatreonProfile { get; set; }
        public bool HasXboxProfile { get; set; }
        public bool HasDiscordProfile { get; set; }
    }
}
