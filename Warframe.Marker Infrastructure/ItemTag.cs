//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Warframe.Market_Infrastructure
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemTag
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int TagID { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
