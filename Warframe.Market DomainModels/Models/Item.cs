﻿using System.Collections.Generic;
using Warframe.Market_DomainModels.Abstractions;
using Warframe.Market_DomainModels.Enums;

namespace Warframe.Market_DomainModels.Models
{
    public class Item : AEntity
    {
        public Item() { }
        public Item(int id) : base(id) { }

        public string UrlName { get; set; }
        public string Thumb { get; set; }
        public int? Ducats { get; set; }
        public int? TradingTax { get; set; }
        public byte? MasteryLevel { get; set; }
        public byte? MaxRank { get; set; }
        public string Icon { get; set; }
        public Translation Description { get; set; }
        public IconFormat? IconFormat { get; set; }
        public Translation WikiLink { get; set; }
        public Translation ItemName { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<SetItem> SetItems { get; set; }
    }
}