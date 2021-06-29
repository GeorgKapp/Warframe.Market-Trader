using System.Runtime.Serialization;

namespace Warframe.Market_Api.JsonData.Enums
{
    public enum SubType
    {
        [EnumMember(Value = "intact")]
        Intact,

        [EnumMember(Value = "exceptional")]
        Exceptional,

        [EnumMember(Value = "flawless")]
        Flawless,

        [EnumMember(Value = "radiant")]
        Radiant
    }
}
