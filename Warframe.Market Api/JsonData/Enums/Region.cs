using System.Runtime.Serialization;

namespace Warframe.Market_Api.JsonData.Enums
{
    public enum Region 
    {
        [EnumMember(Value = "de")]
        De,

        [EnumMember(Value = "en")]
        En,

        [EnumMember(Value = "fr")]
        Fr,

        [EnumMember(Value = "ko")]
        Ko,

        [EnumMember(Value = "ru")]
        Ru,

        [EnumMember(Value = "sv")]
        Sv
    };
}
