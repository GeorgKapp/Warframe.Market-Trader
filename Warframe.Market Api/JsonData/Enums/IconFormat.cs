using System.Runtime.Serialization;

namespace Warframe.Market_Api.JsonData.Enums
{
    public enum IconFormat
    {
        [EnumMember(Value = "land")]
        Land,

        [EnumMember(Value = "port")]
        Port
    }
}
