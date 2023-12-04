using System.Text;

namespace GeoTaggr.Core.Utils;

public static class TextUtils
{
    public const string AlphaChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    public const string AlphaNumericChars = AlphaChars + NumericChars;
    public const string NumericChars = "0123456789";

    public static string GenerateRandomAlphaString(int length)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            string randChar = GenerateRandomCharacter();
            sb.Append(randChar);
        }

        return sb.ToString();
    }

    public static string GenerateRandomCharacter()
    {
        return PickRandomCharacter(AlphaChars);
    }

    public static string? FirstNonEmpty(params string?[] strings)
    {
        return strings.FirstOrDefault(x => !string.IsNullOrEmpty(x));
    }

    public static string PickRandomCharacter(string fromString)
    {
        Random rand = new Random();
        int index = rand.Next(fromString.Length - 1);
        return fromString.Substring(index, 1);
    }
}
