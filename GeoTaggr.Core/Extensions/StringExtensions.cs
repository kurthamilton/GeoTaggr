using System.Text.RegularExpressions;

namespace GeoTaggr.Core.Extensions;

public static class StringExtensions
{
    private static readonly Regex PascalCaseRegex = new(@"([A-Z][a-z]*)", RegexOptions.Compiled);

    public static string EnsureTrailing(this string str, string trailing)
    {
        if (!str.EndsWith(trailing))
        {
            str += trailing;
        }

        return str;
    }

    public static string PascalCaseToWords(this string str)
    {
        MatchCollection matches = PascalCaseRegex.Matches(str);
        if (matches.Count == 0)
        {
            throw new ArgumentException($"String {str} is not in pascal case");
        }

        return string.Join(" ", matches.Select(x => x.Value));
    }
}