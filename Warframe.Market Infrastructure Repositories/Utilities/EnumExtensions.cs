using System;

namespace Warframe.Market_Infrastructure_Repositories.Utilities
{
    internal static class EnumExtensions
    {
        public static T ParseEnum<T>(this string value) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
