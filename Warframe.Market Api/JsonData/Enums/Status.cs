using System.Runtime.Serialization;

namespace Warframe.Market_Api.JsonData.Enums
{
    public enum Status 
    {
        [EnumMember(Value = "ingame")]
        Ingame,

        [EnumMember(Value = "offline")]
        Offline,

        [EnumMember(Value = "online")]
        Online 
    };
}
