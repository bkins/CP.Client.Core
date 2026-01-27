using System.Collections.Generic;

namespace CP.Client.Core.Avails
{
    public static class ListStringExtensions
    {
        public static bool ContainsCaseInsensitive (this List<string> value
                                                  , string            searchTerm)
        {
            return Shared.Primitives.Avails.Extensions.ListStringExtensions.ContainsCaseInsensitive(value
                                                                                                  , searchTerm);
        }

        public static bool DoesNotContainCaseInsensitive (this List<string> value
                                                        , string            searchTerm)
        {
            return Shared.Primitives.Avails.Extensions.ListStringExtensions.DoesNotContainCaseInsensitive(value
                                                                                                        , searchTerm);
        }

        public static bool HasEntries (this List<string> value)
        {
            return Shared.Primitives.Avails.Extensions.ListStringExtensions.HasEntries(value);
        }
    }
}