using System.Collections.Generic;
using Warframe.Market_DomainModels.Abstractions;

namespace Warframe.Market_DomainModels.Models
{
    public class Tag : AEntity
    {
        public Tag() { }
        public Tag(int id) : base(id) { }

        public string Text { get; set; }
    }
}
