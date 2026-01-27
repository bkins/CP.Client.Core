using System.Text.RegularExpressions;
using CP.Client.Core.Avails;

namespace CP.Client.Core.Intent
{
    /*
     * Example usages:
     * 1)
     * var req = new ConverseRequest
                 {
                       Input = userText
                     , FastPath = FastPathIntentDetector.IsFastPathIntent(userText)
                     , Streaming = streamingEnabled
                 };
     * 2)
     * User input: "Journal: Today I fixed FastPath"
     * if (FastPathIntentDetector.TryGetPrefix(userText, out string actionName, out string payload)
     * {
     *      var intent = new 
     *      {
                Intent = "FastPath"
              , ActionHint = actionName
              , Payload = payLoad
              , RawInput = userText 
            }
        }
     */
    public static class FastPathIntentDetector
    {
        // Prefix must be the FIRST token: "Journal:" / "AddJournalEntry:" etc.
        private static readonly Regex PrefixRegex = new Regex(@"^\s*(?<name>[A-Za-z][A-Za-z0-9_-]{1,39})\s*:\s*(?<payload>.+)$",
                                                              RegexOptions.Compiled);

        public static bool IsFastPathIntent(string? input) => TryGetPrefix(input, out _, out _);

        public static bool TryGetPrefix(string? input, out string actionName, out string payload)
        {
            actionName = string.Empty;
            payload    = string.Empty;

            if (input?.HasNoValue() ?? true)
                return false;

            var match = PrefixRegex.Match(input);
            if (match.Success.Not())
                return false;

            actionName = match.Groups["name"].Value;
            payload    = match.Groups["payload"].Value.Trim();

            return payload.Length > 0;
        }
    }
}