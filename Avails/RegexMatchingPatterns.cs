using System.Text.RegularExpressions;

namespace CP.Client.Core.Avails
{
    /// <summary>
    /// Central repository for reusable regular expression string patterns.
    /// </summary>
    public static class RegexMatchingPatterns
    {
    
        #region 🔧 Structural & Key-Value Parsing
    
        /// <summary>
        /// Matches a string starting with an alphanumeric key/prefix followed by a colon, 
        /// capturing the key in Group 1 and the entire remainder in Group 2.
        /// <para>Example: "MyKey: balance of the string..."</para>
        /// </summary>
        public const string ColonSeparatedKeyValuePattern = Shared.Primitives.Avails.RegexMatchingPatterns.ColonSeparatedKeyValuePattern;

        /// <summary>
        /// Matches a key-value pattern with strict bounds (1-39 chars for name), trimming whitespace around the name.
        /// <para>Captures: 'name', 'payload'</para>
        /// <para>Example: " my-workspace_123 : payload text here "</para>
        /// </summary>
        public const string NamedPayloadPattern = Shared.Primitives.Avails.RegexMatchingPatterns.NamedPayloadPattern;

        /// <summary>
        /// Matches anything enclosed inside curly braces.
        /// <para>Example: "{ ""key"": ""value"" }"</para>
        /// </summary>
        public const string CurlyBraceContentPattern = Shared.Primitives.Avails.RegexMatchingPatterns.CurlyBraceContentPattern;

        /// <summary>
        /// Matches an entire line of text wrapped in double quotes.
        /// <para>Captures: Group 1 (inner text without quotes)</para>
        /// </summary>
        public const string DoubleQuotedStringPattern = Shared.Primitives.Avails.RegexMatchingPatterns.DoubleQuotedStringPattern;

        /// <summary>
        /// Matches exactly 32 hexadecimal characters (common for MD5 hashes or UUIDs without hyphens).
        /// <para>Example: "098f6bcd4621d373cade4e832627b4f6"</para>
        /// </summary>
        public const string Hex32HashPattern = Shared.Primitives.Avails.RegexMatchingPatterns.Hex32HashPattern;

        /// <summary>
        /// Matches one or more sequential whitespace characters.
        /// </summary>
        public const string WhitespacePattern = Shared.Primitives.Avails.RegexMatchingPatterns.WhitespacePattern;

        /// <summary>
        /// Matches multiple leading zeros that are followed by a decimal point, preventing leading zero stripping on decimals.
        /// <para>Example: Matches "00" in "00.123"</para>
        /// </summary>
        public const string MultiLeadingZeroDecimalPattern = Shared.Primitives.Avails.RegexMatchingPatterns.MultiLeadingZeroDecimalPattern;

        #endregion

        #region 🤖 CLI & LLM Intent Commands

        /// <summary>
        /// Matches environment commands like switching or using a target context.
        /// <para>Captures: Group 1 (target context/workspace)</para>
        /// <para>Example: "switch to production", "use staging"</para>
        /// </summary>
        public const string CommandSwitchContextPattern = Shared.Primitives.Avails.RegexMatchingPatterns.CommandSwitchContextPattern;

        /// <summary>
        /// Matches queries asking for available models.
        /// <para>Example: "list models", "show models", "what models are available"</para>
        /// </summary>
        public const string CommandListModelsPattern = Shared.Primitives.Avails.RegexMatchingPatterns.CommandListModelsPattern;

        /// <summary>
        /// Matches queries asking for available providers.
        /// <para>Example: "list providers", "show providers", "what providers are available"</para>
        /// </summary>
        public const string CommandListProvidersPattern = Shared.Primitives.Avails.RegexMatchingPatterns.CommandListProvidersPattern;

        /// <summary>
        /// Extracts tokens-per-second performance metrics.
        /// <para>Captures: 'tok' (integer or decimal)</para>
        /// <para>Example: "@ 45.2 tok/s", "@ 12 tok/s"</para>
        /// </summary>
        public const string TokenSpeedPattern = Shared.Primitives.Avails.RegexMatchingPatterns.TokenSpeedPattern;

        #endregion

        #region 📝 Markdown & Document Parsing

        /// <summary>
        /// Matches Markdown headers (H1 through H6).
        /// <para>Example: "### My Heading"</para>
        /// </summary>
        public const string MarkdownHeaderPattern = Shared.Primitives.Avails.RegexMatchingPatterns.MarkdownHeaderPattern;

        /// <summary>
        /// Matches Markdown bold or italicized text wrapper formatting.
        /// <para>Captures: Group 1 (inner text)</para>
        /// <para>Example: "**bold**", "*italic*"</para>
        /// </summary>
        public const string MarkdownEmphasisPattern = Shared.Primitives.Avails.RegexMatchingPatterns.MarkdownEmphasisPattern;

        /// <summary>
        /// Matches Markdown inline code blocks or multi-line code fences.
        /// <para>Example: "`code`", "```csharp ... ```"</para>
        /// </summary>
        public const string MarkdownInlineCodePattern = Shared.Primitives.Avails.RegexMatchingPatterns.MarkdownInlineCodePattern;

        /// <summary>
        /// Matches Markdown code blocks markers, optionally specifying 'json'.
        /// <para>Example: "```json" or "```"</para>
        /// </summary>
        public const string MarkdownCodeBlockFencePattern = Shared.Primitives.Avails.RegexMatchingPatterns.MarkdownCodeBlockFencePattern;

        /// <summary>
        /// Matches Markdown image links.
        /// <para>Example: "![Alt Text](https://image.url)"</para>
        /// </summary>
        public const string MarkdownImageLinkPattern = Shared.Primitives.Avails.RegexMatchingPatterns.MarkdownImageLinkPattern;

        /// <summary>
        /// Matches standard Markdown hyperlinks.
        /// <para>Captures: Group 1 (anchor text)</para>
        /// <para>Example: "[Click Here](https://google.com)"</para>
        /// </summary>
        public const string MarkdownHyperlinkPattern = Shared.Primitives.Avails.RegexMatchingPatterns.MarkdownHyperlinkPattern;

        #endregion

        #region 📅 Dates, Timeframes & Task Trackers

        /// <summary>
        /// Matches structured task lists lines with an id, title, status, and optional tags.
        /// <para>Captures: 'id', 'title', 'status', 'tags'</para>
        /// <para>Example: "- a1b2c3d4: Fix bugs [In Progress] [tags: urgent, ui]"</para>
        /// </summary>
        public const string StructuredTaskLinePattern = Shared.Primitives.Avails.RegexMatchingPatterns.StructuredTaskLinePattern;

        /// <summary>
        /// Matches relative due dates using text keywords at the end of a line.
        /// <para>Captures: Group 1 (date/time string)</para>
        /// <para>Example: "... due by Friday", "... until 10/24/2026"</para>
        /// </summary>
        public const string DueDateSuffixPattern = Shared.Primitives.Avails.RegexMatchingPatterns.DueDateSuffixPattern;

        /// <summary>
        /// Matches upcoming relative calendar increments.
        /// <para>Captures: Group 1 (number), Group 2 (unit: day/week/month)</para>
        /// <para>Example: "in 3 days", "in 1 week"</para>
        /// </summary>
        public const string RelativeTimeframePattern = Shared.Primitives.Avails.RegexMatchingPatterns.RelativeTimeframePattern;

        /// <summary>
        /// Parses explicit duration strings containing hours, minutes, and seconds.
        /// <para>Captures: 'hours', 'minutes', 'seconds'</para>
        /// <para>Example: "2h30m15s", "45m", "10s"</para>
        /// </summary>
        public const string DurationParserPattern = Shared.Primitives.Avails.RegexMatchingPatterns.DurationParserPattern;

        #endregion

        #region 🧠 NLP / Semantic Text Intent Classification

        /// <summary>
        /// Matches explicit memory command boundaries.
        /// </summary>
        public const string IntentRememberPattern = Shared.Primitives.Avails.RegexMatchingPatterns.IntentRememberPattern;

        /// <summary>
        /// Matches actionable item or assignment boundaries.
        /// </summary>
        public const string IntentTaskPattern = Shared.Primitives.Avails.RegexMatchingPatterns.IntentTaskPattern;

        /// <summary>
        /// Matches user profile preferences or identification cues.
        /// </summary>
        public const string IntentUserPreferencePattern = Shared.Primitives.Avails.RegexMatchingPatterns.IntentUserPreferencePattern;

        /// <summary>
        /// Matches critical safety, medical conditions, or emergency keywords.
        /// </summary>
        public const string IntentEmergencyPattern = Shared.Primitives.Avails.RegexMatchingPatterns.IntentEmergencyPattern;

        /// <summary>
        /// Matches executive content requests or summarization signals.
        /// </summary>
        public const string IntentSummaryPattern = Shared.Primitives.Avails.RegexMatchingPatterns.IntentSummaryPattern;

        public const string AnsiEscapeCodePattern = Shared.Primitives.Avails.RegexMatchingPatterns.AnsiEscapeCodePattern;
        #endregion

        #region 🛠️ Dynamic Runtime Pattern Builders

        /// <summary>
        /// Generates a pattern string to extract a trailing value for a specific key dynamically at runtime.
        /// <para>Captures: 'value'</para>
        /// </summary>
        /// <param name="key">The key name to match against.</param>
        public static string CreateDynamicKeyLookupPattern(string key)
        {
            return Shared.Primitives.Avails.RegexMatchingPatterns.CreateDynamicKeyLookupPattern(key);
        }
        
        #endregion

    }
}

// TODO: Consider converting this class to 'source-generated regex':
/*
 * Source-generated regexes (available in .NET 7+) can offer better performance by generating optimized code at compile time.
```
public static partial class CommonRegexes
{
    [GeneratedRegex(@"^([A-Za-z][A-Za-z0-9_-]*):\s+(.+)$", RegexOptions.Singleline)]
    public static partial Regex ColonSeparatedKeyValue();
}
```
 */