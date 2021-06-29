using System.Runtime.Serialization;

namespace Warframe.Market_Api.JsonData.Enums
{
    public enum OrderType
    {
        [EnumMember(Value = "sell")]
        Sell,

        [EnumMember(Value = "buy")]
        Buy
    }
}
