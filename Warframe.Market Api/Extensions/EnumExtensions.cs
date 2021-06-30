using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Warframe.Market_Api.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the EnumMember Value of the given enum
        /// </summary>
        /// <typeparam name="T">the type of the enum that will be used</typeparam>
        /// <param name="value">the value of the enum</param>
        /// <returns>the EnumMember Value of the enum</returns>
        public static string GetEnumMemberValue<T>(this T value)
            where T : Enum
        {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .Single(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
            where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }
}
