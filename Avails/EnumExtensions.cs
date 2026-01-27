using System;

namespace CP.Client.Core.Avails
{
    public static class EnumExtensions
    {
        public static string GetDescription (this Enum value)
        {
            return Shared.Primitives.Avails.Extensions.EnumExtensions.GetDescription(value);
        }
    }
}