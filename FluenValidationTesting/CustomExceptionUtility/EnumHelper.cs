using System;
using System.ComponentModel;

namespace FluenValidationTesting.CustomExceptionUtility
{
    /// <summary>
    /// Enum utility
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Get description from enum values
        /// </summary>
        /// <typeparam name="T">Generic enum</typeparam>
        /// <param name="enumValue">current enum value</param>
        /// <returns></returns>
        public static string GetEnumDescription<T>(this T enumValue)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null) 
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }
    }
}
