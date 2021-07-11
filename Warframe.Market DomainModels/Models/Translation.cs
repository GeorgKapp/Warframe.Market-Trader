using Warframe.Market_DomainModels.Abstractions;

namespace Warframe.Market_DomainModels.Models
{
    public class Translation : ADomainModel
    {
        public Translation() { }
        public Translation(int id) : base(id) { }

        public string En { get; set; }
        public string Ru { get; set; }
        public string Ko { get; set; }
        public string Fr { get; set; }
        public string Sv { get; set; }
        public string De { get; set; }
        public string ZhHant { get; set; }
        public string ZhHans { get; set; }
        public string Pt { get; set; }
        public string Es { get; set; }
        public string Pl { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is Translation)
            {
                var referencedTranslation = obj as Translation;
                if (referencedTranslation.En != En) return false;
                if (referencedTranslation.Ru != Ru) return false;
                if (referencedTranslation.Ko != Ko) return false;
                if (referencedTranslation.Fr != Fr) return false;
                if (referencedTranslation.Sv != Sv) return false;
                if (referencedTranslation.De != De) return false;
                if (referencedTranslation.ZhHant != ZhHant) return false;
                if (referencedTranslation.ZhHans != ZhHans) return false;
                if (referencedTranslation.Pt != Pt) return false;
                if (referencedTranslation.Es != Es) return false;
                if (referencedTranslation.Pl != Pl) return false;

                return true;
            }
            return base.Equals(obj);
        }
        public override int GetHashCode() => (En, Ru, Ko, Fr, Sv, De, ZhHant, ZhHans, Pt, Es, Pl).GetHashCode();
    }
}
