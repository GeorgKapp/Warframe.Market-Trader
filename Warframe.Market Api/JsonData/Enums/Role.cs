using System.Runtime.Serialization;

namespace Warframe.Market_Api.JsonData.Enums
{
    public enum Role
    {
        [EnumMember(Value = "anonymous")]
        Anonymous,

        [EnumMember(Value = "user")]
        User,

        [EnumMember(Value = "moderator")]
        Moderator,

        [EnumMember(Value = "admin")]
        Admin,
    }
}
