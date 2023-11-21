using System.Data;

namespace GeoTaggr.Data.Sqlite.Extensions
{
    internal static class SqlDataReaderExtensions
    {
        public static DateTime? GetDateTimeOrNull(this IDataReader reader, int i)
        {
            return reader.IsDBNull(i)
                ? null
                : reader.GetDateTime(i);
        }

        public static double? GetDoubleOrNull(this IDataReader reader, int i)
        {
            return reader.IsDBNull(i)
                ? null
                : reader.GetDouble(i);
        }

        public static int? GetIntOrNull(this IDataReader reader, int i)
        {
            return reader.IsDBNull(i)
                ? null
                : reader.GetInt32(i);
        }

        public static string? GetStringOrNull(this IDataReader reader, int i)
        {
            return reader.IsDBNull(i)
                ? null
                : reader.GetString(i);
        }
    }
}
