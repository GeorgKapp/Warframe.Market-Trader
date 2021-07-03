using System;
using Warframe.Market_DomainModels.Abstractions;
using Warframe.Market_DomainModels.Enums;

namespace Warframe.Market_DomainModels.Models
{
    public class User : ADomainModel
    {
        public User() { }
        public User(int id) : base(id) { }

        public string InGameName { get; set; }
        public DateTimeOffset? LastSeen { get; set; }
        public int Reputation { get; set; }
        public string Avatar { get; set; }
        public Region? Region { get; set; }
        public Status? Status { get; set; }
    }
}
