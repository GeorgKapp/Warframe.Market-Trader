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
        /// <param name="enumValue">the value of the enum</param>
        /// <returns>the EnumMember value of the enum</returns>
        public static string GetEnumMemberValue(this Enum enumValue)
        {
            return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<EnumMemberAttribute>()
                        .Value;
        }

        /// <summary>
        /// Gets the Attribute Value of the given enum
        /// </summary>
        /// <typeparam name="TAttribute">the type of attribute that will be looked up</typeparam>
        /// <param name="enumValue">the value of the enum</param>
        /// <returns>the Attribute value of the enum</returns>
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
