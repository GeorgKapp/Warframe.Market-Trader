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
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.ItemTag = new HashSet<ItemTag>();
            this.SetItem = new HashSet<SetItem>();
            this.SetItem1 = new HashSet<SetItem>();
        }
    
        public int ID { get; set; }
        public string UrlName { get; set; }
        public string Thumb { get; set; }
        public Nullable<int> Ducats { get; set; }
        public Nullable<int> TradingTax { get; set; }
        public Nullable<byte> MasteryLevel { get; set; }
        public Nullable<byte> MaxRank { get; set; }
        public string Icon { get; set; }
        public Nullable<int> IconFormatID { get; set; }
        public Nullable<int> DescriptionID { get; set; }
        public Nullable<int> WikiLinkID { get; set; }
        public Nullable<int> ItemNameID { get; set; }
    
        public virtual Translation Translation { get; set; }
        public virtual IconFormatType IconFormatType { get; set; }
        public virtual Translation Translation1 { get; set; }
        public virtual Translation Translation2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemTag> ItemTag { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SetItem> SetItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SetItem> SetItem1 { get; set; }
    }
}
