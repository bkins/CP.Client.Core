using System;
using System.Collections.Generic;

namespace CP.Client.Core.Avails
{
    public static class StringExtensions
    {
        public static bool HasValue(this string value)
        {
            return Shared.Primitives.Avails.Extensions.StringExtensions.HasValue(value);
        }

        public static bool HasNoValue (this string value)
        {
            return Shared.Primitives.Avails.Extensions.StringExtensions.HasNoValue(value);
        }

        public static bool DoesNotContain (this List<string> value, string searchTerm)
        {
            return Shared.Primitives.Avails.Extensions.StringExtensions.DoesNotContain(value, searchTerm);
        }

        public static bool IsEmptyNullOrWhiteSpace (this string value)
        {
            return Shared.Primitives.Avails.Extensions.StringExtensions.IsEmptyNullOrWhiteSpace(value);
        }

        public static bool IsEqualTo (this string value, string compareValue, StringComparison  comparisonType)
        {
            return Shared.Primitives.Avails.Extensions.StringExtensions.IsEqualTo(value, compareValue, comparisonType);
        }
        
        public static bool IsEqualTo (this string value, string compareValue)
        {
            return Shared.Primitives.Avails.Extensions.StringExtensions.IsEqualTo(value, compareValue);
        }
        
        public static bool IsNotEqualTo (this string      value
                                       , string           compareValue
                                       , StringComparison comparisonType)
        {
            return Shared.Primitives.Avails.Extensions.StringExtensions.IsNotEqualTo(value, compareValue, comparisonType);
        }

        public static bool IsNotEqualTo (this string      value
                                       , string           compareValue)
        {
            return Shared.Primitives.Avails.Extensions.StringExtensions.IsNotEqualTo(value, compareValue);
        }
        
        public static bool IsInt (this string value)
        {
            return Shared.Primitives.Avails.Extensions.StringExtensions.IsInt(value);
        }

        public static bool IsNotInt (this string value)
        {
            return Shared.Primitives.Avails.Extensions.StringExtensions.IsNotInt(value);
        }
    }
}