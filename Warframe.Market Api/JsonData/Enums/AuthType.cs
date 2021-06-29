using System.Runtime.Serialization;

namespace Warframe.Market_Api.JsonData.Enums
{
    public enum AuthType
    {
        [EnumMember(Value = "cookie")]
        Cookie,

        [EnumMember(Value = "header")]
        Header
    }
}
