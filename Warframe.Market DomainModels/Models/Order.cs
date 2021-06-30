using System;
using Warframe.Market_DomainModels.Enums;

namespace Warframe.Market_DomainModels.Models
{
    public class Order
    {
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public int Quantity { get; set; }
        public bool Visible { get; set; }
        public int Platinum { get; set; }
        public byte? ModRank { get; set; }
        public int UserID { get; set; }
        public OrderType OrderType { get; set; }
        public Platform Platform { get; set; }
        public Region Region { get; set; }
        public SubType SubType { get; set; }
        public User User { get; set; }
    }
}
