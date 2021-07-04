using System;

namespace Warframe.Market_Infrastructure_Repositories.Utilities
{
    internal static class EnumExtensions
    {
        public static T ParseEnum<T>(this string value) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static int? ParseToID<T>(this T value)
        {
            if (value == null)
                return null;

            Type genericType = typeof(T);
            if (genericType.IsEnum)
            {
                return Convert.ToInt32(value);
            }
            return null;
        }
    }
}
