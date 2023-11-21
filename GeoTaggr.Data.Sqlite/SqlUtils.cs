using System.Data;
using System.Data.SQLite;

namespace GeoTaggr.Data.Sqlite
{
    internal static class SqlUtils
    {
        public static IDataParameter GetParameter(string name, object? value, DbType type)
        {
            IDataParameter parameter = new SQLiteParameter();
            parameter.ParameterName = name;
            parameter.DbType = type;

            if (value != null)
            {
                parameter.Value = value;
            }
            else
            {
                parameter.Value = DBNull.Value;
            }
            return parameter;
        }
    }
}
