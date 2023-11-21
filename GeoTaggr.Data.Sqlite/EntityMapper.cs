using System.Data;

namespace GeoTaggr.Data.Sqlite
{
    public abstract class EntityMapper<T> : IEntityMapper<T>
    {
        public abstract IReadOnlyCollection<string> InsertColumns { get; }        

        public string InsertSql =>
            $"INSERT INTO {TableName} ({InsertColumnSql}) VALUES ({InsertColumnVariables})";

        public abstract IReadOnlyCollection<string> SelectColumns { get; }

        public string SelectColumnSql => string.Join(", ", SelectColumns.Select(x => $"{TableName}.{x}"));

        public abstract string TableName { get; }

        public abstract IReadOnlyCollection<IDataParameter> InsertParameters(T entity);

        public abstract T Map(IDataReader reader);        

        private string InsertColumnSql => string.Join(", ", InsertColumns);

        private string InsertColumnVariables => string.Join(", ", InsertColumns.Select(x => $"@{x}"));

        protected IDataParameter GetParameter(string name, object? value, DbType type)
        {
            return SqlUtils.GetParameter(name, value, type);
        }
    }
}
